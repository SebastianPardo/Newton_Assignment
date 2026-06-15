import { Component, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { VideoGame } from '../../models/VideoGame';
import { CatalogueServices } from '../../services/catalogue-services';

@Component({
  selector: 'app-catalogue',
  standalone: false,
  templateUrl: './catalogue.html',
  styleUrl: './catalogue.css',
})
export class Catalogue implements OnInit {
  games = signal<VideoGame[]>([]);
  isLoading = signal(true);
  errorMessage = signal('');

  constructor(
    private videoGameService: CatalogueServices,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.videoGameService.getAll().subscribe({
      next: (data) => {
        this.games.set(data);
        this.isLoading.set(false);
      },
      error: () => {
        this.errorMessage.set('Error loading games.');
        this.isLoading.set(false);
      }
    });
  }

  goToEdit(id: string): void {
    this.router.navigate(['/edit', id]);
  }
}
