import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { from } from 'rxjs';
import { UUID } from 'angular2-uuid';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  uuidValue:string;
  constructor() {

  }

  generateUUID() {
    this.uuidValue=UUID.UUID();
    return this.uuidValue;
  }
}
