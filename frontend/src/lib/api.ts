import { getAccessToken } from "./auth";

const API_BASE = import.meta.env.VITE_API_URL ?? "";

async function authHeaders(): Promise<HeadersInit> {
  const token = await getAccessToken();
  return {
    "Content-Type": "application/json",
    ...(token ? { Authorization: `Bearer ${token}` } : {}),
  };
}

interface ValidationProblem {
  title?: string;
  errors?: Record<string, string[]>;
}

export class ApiValidationError extends Error {
  errors: Record<string, string[]>;

  constructor(problem: ValidationProblem) {
    super(problem.title ?? "Validation failed");
    this.errors = problem.errors ?? {};
  }
}

export interface UserProfile {
  id: string;
  email: string;
  displayName: string;
  avatarUrl: string | null;
  workspaces: WorkspaceSummary[];
}

export interface WorkspaceSummary {
  id: string;
  name: string;
  slug: string;
  role: string;
}

export interface OnboardingResponse {
  userId: string;
  email: string;
  workspaceSlug: string;
}

/** Returns the current user's profile, or null if no DB user exists yet. */
export async function getMe(): Promise<UserProfile | null> {
  const res = await fetch(`${API_BASE}/api/me`, {
    headers: await authHeaders(),
  });

  if (res.status === 404) return null;
  if (!res.ok) throw new Error("Failed to fetch user profile.");

  return res.json();
}

/** Creates the user's DB record and first workspace. */
export async function createWorkspace(
  workspaceName: string,
): Promise<OnboardingResponse> {
  const res = await fetch(`${API_BASE}/api/onboarding`, {
    method: "POST",
    headers: await authHeaders(),
    body: JSON.stringify({ workspaceName }),
  });

  if (res.status === 400) {
    const problem: ValidationProblem = await res.json();
    throw new ApiValidationError(problem);
  }

  if (!res.ok) throw new Error("Failed to create workspace.");

  return res.json();
}
