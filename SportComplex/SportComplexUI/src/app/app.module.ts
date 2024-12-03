import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Імпортуємо створені елементи
import { SharedModule } from './shared/shared.module'; // Ваш новий модуль
import { HomeComponent } from './components/home/home.component'; // Ваш компонент

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent // Реєструємо компонент
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule // Імпортуємо модуль
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
