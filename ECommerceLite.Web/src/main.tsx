import { StrictMode, type FC } from 'react';
import { createRoot, type Root } from 'react-dom/client';
import "./index.css";
import App from './App.js';
import { ReactKeycloakProvider, useKeycloak } from '@react-keycloak/web'

import keycloak from './keycloak.tsx'
  // Your component in TypeScript would look like this
//import React, { FC } from 'react';

var thingy = document.getElementById('root') as HTMLElement;
const root : Root = createRoot(thingy);


//const { keycloak, initialized } = useKeycloak();

root.render(
  <StrictMode>
    <ReactKeycloakProvider authClient={keycloak}>
        <App />
    </ReactKeycloakProvider> 
  </StrictMode>
)


document.getElementById('app')
