import { UserManager, WebStorageStateStore } from "oidc-client-ts";

const keycloakUrl = import.meta.env.VITE_KEYCLOAK_URL as string | undefined;
const authority = keycloakUrl ? `${keycloakUrl}/realms/sitrep` : "";

export const userManager = new UserManager({
  authority,
  client_id: "sitrep-frontend",
  redirect_uri: `${window.location.origin}/callback`,
  post_logout_redirect_uri: window.location.origin,
  response_type: "code",
  scope: "openid profile email",
  userStore: new WebStorageStateStore({ store: window.localStorage }),
  automaticSilentRenew: true,
});

export function login() {
  return userManager.signinRedirect();
}

export function register() {
  // Keycloak supports kc_action=register to go directly to registration form
  return userManager.signinRedirect({
    extraQueryParams: { kc_action: "register" },
  });
}

export function logout() {
  return userManager.signoutRedirect();
}

export async function getAccessToken(): Promise<string | null> {
  const user = await userManager.getUser();
  return user?.access_token ?? null;
}
