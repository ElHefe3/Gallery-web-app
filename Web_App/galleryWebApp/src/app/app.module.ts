import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { ImageComponent } from './image/image.component';
import { RouterModule } from '@angular/router';
import { AlbumComponent } from './album/album.component';
import { LoginComponent } from './login/login.component';
import {MatDialogModule} from '@angular/material/dialog'; 

@NgModule({
  declarations: [
    AppComponent,
    ImageComponent,
    AlbumComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '',component: LoginComponent, pathMatch: 'full'},
      {path: 'album', component: ImageComponent },
      {path: 'image', component: ImageComponent }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
