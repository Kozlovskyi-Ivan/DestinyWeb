import { DataserviceService } from './dataservice.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { MainboardComponent } from './mainboard/mainboard.component';
import { FlashpointComponent } from './flashpoint/flashpoint.component';
import { HttpClientModule } from '@angular/common/http';
import { NightfallComponent } from './nightfall/nightfall.component';
import { CrucibleComponent } from './crucible/crucible.component';
import { RaidComponent } from './raid/raid.component';


const appRoutes: Routes = [
  {path: '', component: MainboardComponent},
  {path: 'a', component: FlashpointComponent}
];

@NgModule({
   declarations: [
      AppComponent,
      MainboardComponent,
      FlashpointComponent,
      NightfallComponent,
      CrucibleComponent,
      RaidComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      DataserviceService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
