import {Component} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'z-vocengl-client1';

  goTop($event: MouseEvent): void {
    console.log('scroll');
    let pos = window.pageYOffset;
    // document.body.scrollTo({top: 0, behavior: 'smooth'})
    window.scrollTo({top: 0, behavior: 'smooth'});
  }
}
