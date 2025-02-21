import { Component, inject } from '@angular/core';

import { HeroService } from '../../hero.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-admin-hero-list',
  standalone: true,
  imports: [AsyncPipe],
  template: `
    <p>Authentication required for see the list of heroes with their id, license, and country information</p>

    <table class="heroes">
      <tr>
        <th>Id</th><th>Name</th><th>License #</th><th>Country</th>
      </tr>
      @for (hero of heroes$ | async; track hero.id) {
        <tr class="hero">
          <td>{{ hero.id }}</td>
          <td>{{ hero.name }}</td>
          <td>{{hero.license}}</td>
          <td>{{hero.country}}</td>
      </tr>
      }
    </table>
  `,
  styleUrls: ['./admin-hero-list.component.scss']
})
export class AdminHeroListComponent {
  private heroesService = inject(HeroService);
  heroes$ = this.heroesService.getFullHeroes();
}
