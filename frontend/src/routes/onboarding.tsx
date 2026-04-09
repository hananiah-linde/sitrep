import { type FormEvent, useState } from "react";
import { createFileRoute, useNavigate } from "@tanstack/react-router";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { ApiValidationError, createWorkspace } from "@/lib/api";

export const Route = createFileRoute("/onboarding")({
  component: OnboardingPage,
});

function OnboardingPage() {
  const navigate = useNavigate();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [fieldErrors, setFieldErrors] = useState<Record<string, string[]>>({});
  const [generalError, setGeneralError] = useState<string | null>(null);

  async function handleSubmit(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();
    setFieldErrors({});
    setGeneralError(null);

    const formData = new FormData(e.currentTarget);
    const workspaceName = (formData.get("workspaceName") as string).trim();

    if (!workspaceName) {
      setFieldErrors({ workspaceName: ["Workspace name is required."] });
      return;
    }

    setIsSubmitting(true);
    try {
      await createWorkspace(workspaceName);
      await navigate({ to: "/" });
    } catch (err) {
      if (err instanceof ApiValidationError) {
        setFieldErrors(err.errors);
      } else {
        setGeneralError(
          err instanceof Error ? err.message : "An unexpected error occurred.",
        );
      }
    } finally {
      setIsSubmitting(false);
    }
  }

  return (
    <div className="flex min-h-screen items-center justify-center px-4">
      <Card className="w-full max-w-md">
        <CardHeader className="text-center">
          <CardTitle className="text-2xl font-bold">
            Create your workspace
          </CardTitle>
          <CardDescription>
            A workspace is where your team organizes issues and projects.
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form onSubmit={handleSubmit} className="space-y-4">
            {generalError && (
              <div className="rounded-md bg-destructive/10 p-3 text-sm text-destructive">
                {generalError}
              </div>
            )}

            <div className="space-y-2">
              <Label htmlFor="workspaceName">Workspace name</Label>
              <Input
                id="workspaceName"
                name="workspaceName"
                placeholder="My Company"
                autoComplete="organization"
                autoFocus
              />
              {fieldErrors.workspaceName && (
                <p className="text-sm text-destructive">
                  {fieldErrors.workspaceName[0]}
                </p>
              )}
            </div>

            <Button type="submit" className="w-full" disabled={isSubmitting}>
              {isSubmitting ? "Creating workspace..." : "Create workspace"}
            </Button>
          </form>
        </CardContent>
      </Card>
    </div>
  );
}
