import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';

@Component({
  selector: 'app-heroes', //CSS element selector
  templateUrl: './heroes.component.html', //The location of the component's template file.
  styleUrls: ['./heroes.component.css'] //The location of the component's private CSS styles.
})
export class HeroesComponent implements OnInit {

  hero: Hero = {
    id: 1,
    name: 'Windstorm'
  }
  
  constructor() { }
  
  ngOnInit(): void {
  }
  
}