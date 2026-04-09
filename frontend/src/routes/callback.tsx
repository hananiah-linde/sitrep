import { useEffect, useRef } from "react";
import { createFileRoute, useNavigate } from "@tanstack/react-router";
import { userManager } from "@/lib/auth";
import { getMe } from "@/lib/api";

export const Route = createFileRoute("/callback")({
  component: CallbackPage,
});

function CallbackPage() {
  const navigate = useNavigate();
  const handled = useRef(false);

  useEffect(() => {
    if (handled.current) return;
    handled.current = true;

    async function handleCallback() {
      try {
        await userManager.signinRedirectCallback();
        const profile = await getMe();
        if (profile) {
          await navigate({ to: "/" });
        } else {
          await navigate({ to: "/onboarding" });
        }
      } catch (err) {
        console.error("OIDC callback failed:", err);
        await navigate({ to: "/" });
      }
    }

    handleCallback();
  }, [navigate]);

  return (
    <div className="flex min-h-screen items-center justify-center">
      <p className="text-muted-foreground">Signing you in...</p>
    </div>
  );
}
