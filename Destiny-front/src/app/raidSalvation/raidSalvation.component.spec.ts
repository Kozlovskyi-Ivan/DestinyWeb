/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RaidSalvationComponent } from './raidSalvation.component';

describe('RaidSalvationComponent', () => {
  let component: RaidSalvationComponent;
  let fixture: ComponentFixture<RaidSalvationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaidSalvationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaidSalvationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
