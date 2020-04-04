/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RaidLastComponent } from './raidLast.component';

describe('RaidLastComponent', () => {
  let component: RaidLastComponent;
  let fixture: ComponentFixture<RaidLastComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaidLastComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaidLastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
