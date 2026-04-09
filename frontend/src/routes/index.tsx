import { createFileRoute } from "@tanstack/react-router";
import { Button } from "@/components/ui/button";
import { useAuth } from "@/lib/auth-context";

export const Route = createFileRoute("/")({
  component: HomePage,
});

function HomePage() {
  const { isAuthenticated, isLoading, login, register, logout } = useAuth();

  if (isLoading) {
    return (
      <div className="flex min-h-screen items-center justify-center">
        <p className="text-muted-foreground">Loading...</p>
      </div>
    );
  }

  return (
    <div className="flex min-h-screen items-center justify-center">
      <div className="text-center">
        <h1 className="text-4xl font-bold tracking-tight">Sitrep</h1>
        <p className="mt-2 text-muted-foreground">
          Issue tracking, simplified.
        </p>
        <div className="mt-6 flex gap-4 justify-center">
          {isAuthenticated ? (
            <Button variant="outline" onClick={() => void logout()}>
              Log Out
            </Button>
          ) : (
            <>
              <Button onClick={() => void register()}>Get Started</Button>
              <Button variant="outline" onClick={() => void login()}>
                Log In
              </Button>
            </>
          )}
        </div>
      </div>
    </div>
  );
}
