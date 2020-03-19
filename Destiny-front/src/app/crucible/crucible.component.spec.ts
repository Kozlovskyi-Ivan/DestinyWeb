/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CrucibleComponent } from './crucible.component';

describe('CrucibleComponent', () => {
  let component: CrucibleComponent;
  let fixture: ComponentFixture<CrucibleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrucibleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrucibleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
