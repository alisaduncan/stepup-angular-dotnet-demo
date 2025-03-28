import { ApplicationConfig, importProvidersFrom, inject, provideAppInitializer } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { HttpBackend, HttpClient, provideHttpClient, withInterceptors } from '@angular/common/http';
import { OktaAuth } from '@okta/okta-auth-js';
import { OktaAuthConfigService, OktaAuthModule } from '@okta/okta-angular';
import { authInterceptor } from './auth.interceptor';
import { stepupInterceptor } from './stepup.interceptor';
import { tap, firstValueFrom } from 'rxjs';

const configInitializer = () => {
  const httpBackend = inject(HttpBackend);
  const configService = inject(OktaAuthConfigService);

  return firstValueFrom(
  new HttpClient(httpBackend)
  .get('https://stepup-auth-config-2fe0cebff4a1.herokuapp.com/config')
  .pipe(
    tap((authConfig: any) => configService.setConfig({oktaAuth: new OktaAuth({...authConfig, redirectUri: `${window.location.origin}/login/callback`, scopes: ['openid', 'profile', 'offline_access']})})),
  ));
}

export const appConfig: ApplicationConfig = {
  providers: [
    importProvidersFrom(
      OktaAuthModule
    ),
    provideRouter(routes),
    provideAppInitializer(configInitializer),
    provideHttpClient(withInterceptors([
      authInterceptor,
      stepupInterceptor
    ]))
  ]
};
