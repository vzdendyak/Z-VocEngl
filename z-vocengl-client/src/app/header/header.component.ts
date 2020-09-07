import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  burgerActive: boolean;
  searchWordForm: FormGroup;


  constructor(private fb: FormBuilder, private router: Router) {
    this.burgerActive = false;
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.searchWordForm = this.fb.group({
      Name: [null]
    });
  }

  burgerClick(): void {
    this.burgerActive = !this.burgerActive;
    // document.body.classList.add('lock');
    // document.body.classList.remove('lock');
    document.body.classList.toggle('lock');
  }


  searchWordSubmit() {
    const wordName = this.searchWordForm.controls.Name.value;
    console.log(wordName);
    this.router.navigateByUrl(`/word/${wordName}`);
  }
}
