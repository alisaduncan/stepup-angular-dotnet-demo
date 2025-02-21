import { Component, inject } from '@angular/core';
import { HeroService } from '../hero.service';
import { take } from 'rxjs';
import { AsyncPipe, JsonPipe } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [RouterLink, RouterOutlet],
  template: `
    <h2>Admin Dashboard</h2>
    <p>Manage your crises and heroes here! These actions are extra sensitive.</p>

    <div class="actions-menu">
      <a routerLink="heroes">Hero list</a>
      <p>Other actions <br/><span class="example-actions">like editing, promoting, or adding new heroes</span></p>
    </div>
    
    <router-outlet/>
  `,
  styleUrls: ['./admin.component.scss']
})
export class AdminDashboardComponent {

  private heroService = inject(HeroService);
}
