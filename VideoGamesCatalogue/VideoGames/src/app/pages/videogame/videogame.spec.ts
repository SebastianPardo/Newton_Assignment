import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Videogame } from './videogame';

describe('Videogame', () => {
  let component: Videogame;
  let fixture: ComponentFixture<Videogame>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Videogame],
    }).compileComponents();

    fixture = TestBed.createComponent(Videogame);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
