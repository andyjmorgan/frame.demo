import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {LocationStrategy, PathLocationStrategy} from "@angular/common";
import { HomeComponent } from './home/home.component';
import {CardModule} from "primeng/card";
import {ToolbarModule} from "primeng/toolbar";
import {AvatarModule} from "primeng/avatar";
import {ButtonModule} from "primeng/button";
import { ToolCardComponent } from './component/tool-card/tool-card.component';
import {TableModule} from "primeng/table";
import {FieldsetModule} from "primeng/fieldset";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ToolCardComponent
  ],
    imports: [
        BrowserModule.withServerTransition({appId: 'serverApp'}),
        HttpClientModule,
        AppRoutingModule,
        CardModule,
      BrowserAnimationsModule,
        ToolbarModule,
        AvatarModule,
        ButtonModule,
        TableModule,
        FieldsetModule
    ],
  providers: [{provide: LocationStrategy, useClass: PathLocationStrategy}],
  bootstrap: [AppComponent]
})
export class AppModule { }
