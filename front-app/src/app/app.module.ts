import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatInputModule} from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { HistoryComponent } from './history/history.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { LoaderInterceptorService } from '../../services/interceptors/loader-interceptor.service';
import { SharedModule } from '../../global/module/shared.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HistoryComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    MatInputModule,
    MatTabsModule,
    MatButtonModule,
    SharedModule,
    MatCardModule,
    MatPaginatorModule,
    MatTableModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptorService,
      multi: true,
    },
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
