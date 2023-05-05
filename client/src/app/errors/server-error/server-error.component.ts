import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  
  error: any;

  constructor(private router: Router) { 
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.['error'];    // 'error' = ~/client/src/app/_interceptors/error.interceptor.ts/@#line43#
  }

  ngOnInit(): void {
  }

}
