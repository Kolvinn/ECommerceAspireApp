import { useAuth0 } from "@auth0/auth0-react";
import { useKeycloak } from "@react-keycloak/web";

const LogoutButton = () => {
  const { keycloak } = useKeycloak()
  return (
    <button
      onClick={() => keycloak?.logout()}
      className="button logout"
    >
      Log Out
    </button>
  );
};

export default LogoutButton;