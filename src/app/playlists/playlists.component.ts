import { Component, OnInit } from '@angular/core';
import { Key } from 'readline';
import { AbstractFormGroupDirective } from '@angular/forms';
import { UUID } from 'angular2-uuid';

@Component({
  selector: 'app-playlists',
  templateUrl: './playlists.component.html',
  styleUrls: ['./playlists.component.css']
})
export class PlaylistsComponent implements OnInit {
  pid: number;
  playlistName: string;
  sid:  Key;
  oid: UUID;

  constructor() { }

  ngOnInit() {
  }

}
