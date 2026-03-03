import * as React from 'react'
import { useCallback } from 'react'

import { useKeycloak } from '@react-keycloak/web'
import LogoutButton from './LogoutButton'

//import { useAxios } from '../utils/hooks'

export default () => {
  const { keycloak } = useKeycloak()

  //const axiosInstance = useAxios('http://localhost:5000') // see https://github.com/panz3r/jwt-checker-server for a quick implementation
  // const callApi = useCallback(() => {
  //   !!axiosInstance.current && axiosInstance.current.get('/jwt/decode')
  // }, [axiosInstance])

  return (
    <div>
      <div>User is {!keycloak?.authenticated ? 'NOT ' : ''} authenticated</div>

       <LogoutButton />

    </div>
  )
}