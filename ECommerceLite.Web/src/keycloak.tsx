import Keycloak from 'keycloak-js'

// Setup Keycloak instance as needed
// Pass initialization options as required or leave blank to load from 'keycloak.json'

const keycloakConfig = {
    realm: 'master',
    url: 'http://localhost:8080',
    clientId: 'clientid69'
};

const keycloak = new Keycloak(keycloakConfig) as Keycloak

export default keycloak