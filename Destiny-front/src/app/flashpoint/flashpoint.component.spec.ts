/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FlashpointComponent } from './flashpoint.component';

describe('FlashpointComponent', () => {
  let component: FlashpointComponent;
  let fixture: ComponentFixture<FlashpointComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlashpointComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlashpointComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
