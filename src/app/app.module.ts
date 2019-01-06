import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PlaylistsComponent } from './playlists/playlists.component';
import { PlaylistDetailComponent } from './playlist-detail/playlist-detail.component';
import { PlaylistAddComponent } from './playlist-add/playlist-add.component';
import { PlaylistEditComponent } from './playlist-edit/playlist-edit.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  {
    path: 'Playlists',
    component: PlaylistsComponent,
    data: { title: 'List of Playlists' }
  },
  {
    path: 'playlist-detail',
    component: PlaylistDetailComponent,
    data: { title: 'Playlists Details' }
  },
  {
    path: 'playlist-add',
    component: PlaylistAddComponent,
    data: { title: 'Add Playlists' }
  },
  {
    path: 'playlist-edit',
    component: PlaylistEditComponent,
    data: { title: 'Edit Playlists' }
  },
  {
    path: '',
    redirectTo: '/playlist',
    pathMatch: 'full'
  },
]

@NgModule({
  declarations: [
    AppComponent,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    PlaylistsComponent,
    PlaylistDetailComponent,
    PlaylistAddComponent,
    PlaylistEditComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
