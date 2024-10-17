import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
// import { HeaderComponent } from './app/header.component';


bootstrapApplication(AppComponent, {
  providers: [provideHttpClient()]
}).catch((err) => console.error(err));

// bootstrapApplication(HeaderComponent)


// import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
// import { AppModule } from './app/app.module';
// import { bootstrapApplication } from '@angular/platform-browser';
// import { provideHttpClient } from '@angular/common/http';

// platformBrowserDynamic().bootstrapModule(AppModule)
// bootstrapApplication(AppModule, {
//   providers: [provideHttpClient()]
// })
