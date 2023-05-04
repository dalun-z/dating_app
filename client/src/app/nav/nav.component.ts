import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {}
  
  // set the 'accountService' as public so that nav.component.html could use it
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }


  login() {
    // we need to use 'subscribe' method since it's return an observable of the response
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => console.log(error)
    })
  }

  logout() {
    this.accountService.logout();
  }

}
