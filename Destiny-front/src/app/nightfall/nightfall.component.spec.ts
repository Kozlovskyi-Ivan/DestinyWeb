/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NightfallComponent } from './nightfall.component';

describe('NightfallComponent', () => {
  let component: NightfallComponent;
  let fixture: ComponentFixture<NightfallComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NightfallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NightfallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
