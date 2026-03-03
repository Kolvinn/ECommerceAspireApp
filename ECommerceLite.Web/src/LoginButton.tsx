import * as React from 'react'
import { useCallback } from 'react'
import { } from 'react-router-dom'

import { useKeycloak } from '@react-keycloak/web'
import Profile from './Profile'

const LoginButton = () => {
  // const location = useLocation<{ [key: string]: unknown }>()
  // const currentLocationState = location.state || {
  //   from: { pathname: '/home' },
  // }

  const { keycloak } = useKeycloak()

  const login = useCallback(() => {
    keycloak?.login()
  }, [keycloak])

  if (keycloak?.authenticated)
    return <Profile />

  return (
    <div>
      <button type="button" onClick={login}>
        Login
      </button>
    </div>
  )
}

export default LoginButton;