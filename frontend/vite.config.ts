import path from "path"
import tailwindcss from "@tailwindcss/vite"
import { TanStackRouterVite } from "@tanstack/router-plugin/vite"
import react from "@vitejs/plugin-react"
import { defineConfig } from "vite"

// Aspire injects service URLs as services__<name>__<scheme>__<index>.
// Vite only exposes VITE_ prefixed vars to client code, so we bridge them here.
// Prefer HTTP (pinned to port 8080) so the issuer matches what the API expects.
const keycloakUrl =
  process.env.services__keycloak__http__0 ??
  process.env.services__keycloak__https__0 ??
  ""
const apiUrl =
  process.env.services__api__https__0 ??
  process.env.services__api__http__0 ??
  ""

// https://vite.dev/config/
export default defineConfig({
  plugins: [TanStackRouterVite({ quoteStyle: "double" }), react(), tailwindcss()],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
  define: {
    "import.meta.env.VITE_KEYCLOAK_URL": JSON.stringify(keycloakUrl),
    "import.meta.env.VITE_API_URL": JSON.stringify(apiUrl),
  },
  server: {
    port: 5173,
    strictPort: true,
    proxy: apiUrl
      ? {
          "/api": {
            target: apiUrl,
            changeOrigin: true,
            secure: false,
          },
        }
      : undefined,
  },
})
