/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RaidComponent } from './raid.component';

describe('RaidComponent', () => {
  let component: RaidComponent;
  let fixture: ComponentFixture<RaidComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaidComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
