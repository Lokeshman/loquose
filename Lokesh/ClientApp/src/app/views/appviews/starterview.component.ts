import { Component, OnDestroy, OnInit, } from '@angular/core';

@Component({
  selector: 'starter',
  templateUrl: 'starter.template.html',  
  styleUrls: ['starter.template.css']
})
export class StarterViewComponent implements OnDestroy, OnInit  {

  public nav: any;
  public idwrapper;

public constructor() {
  this.nav = document.querySelector('nav.navbar');
  this.idwrapper = document.querySelector('#page-wrapper');
}

public ngOnInit():any {
  this.nav.className += " white-bg1";
  
}


public ngOnDestroy():any {
  this.nav.classList.remove("white-bg1");
  
}

}
