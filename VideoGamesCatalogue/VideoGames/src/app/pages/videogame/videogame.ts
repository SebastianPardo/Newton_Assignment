import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntityVideoGame } from '../../models/EntityVideoGame';
import { CatalogueServices } from '../../services/catalogue-services';
import { PlatformServices } from '../../services/platform-services';
import { GenreServices } from '../../services/genre-services';
import { Genre } from '../../models/Genre';
import { Platform } from '../../models/Platform';

@Component({
  selector: 'app-videogame',
  standalone: false,
  templateUrl: './videogame.html',
  styleUrl: './videogame.css',
})
export class Videogame implements OnInit {
  game = signal<EntityVideoGame | null>(null);
  genres = signal<Genre[]>([]);
  platforms = signal<Platform[]>([]);

  isLoading = signal(true);
  isSaving = signal(false);
  errorMessage = signal('');
  successMessage = signal('');

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private catalogueService: CatalogueServices,
    private genreService: GenreServices,
    private platformService: PlatformServices
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!;

    // Cargar los tres en paralelo
    this.genreService.getAll().subscribe(g => this.genres.set(g));
    this.platformService.getAll().subscribe(p => this.platforms.set(p));

    this.catalogueService.getById(id).subscribe({
      next: (data) => {
        this.game.set(data);
        this.isLoading.set(false);
      },
      error: () => {
        this.errorMessage.set('Error loading game.');
        this.isLoading.set(false);
      }
    });
  }

  save(): void {
    const current = this.game();
    if (!current) return;

    this.isSaving.set(true);
    this.catalogueService.update(current.id, current).subscribe({
      next: () => {
        this.isSaving.set(false);
        this.successMessage.set('Game updated successfully.');
        setTimeout(() => this.router.navigate(['/']), 1500);
      },
      error: () => {
        this.isSaving.set(false);
        this.errorMessage.set('Error saving game.');
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/']);
  }

  updateField(field: keyof EntityVideoGame, value: any): void {
    const current = this.game();
    if (current) this.game.set({ ...current, [field]: value });
  }
}
