import { Component } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'front-app';
  loadHistory = false;
  loadCurrentResult = true;

  onTabChange(event: MatTabChangeEvent) {
    if (event.index === 1) {
      this.loadHistory = true;
      this.loadCurrentResult = false;
    }else{
      this.loadHistory = false;
      this.loadCurrentResult = true;
    }
  }
  routerEvent(event:any){
    console.log('router-outlet ', event);
  }
}
