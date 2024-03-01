import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

interface WeatherForecast {
  time: Date;
  temperatureC: number;
  temperatureF: number;
  location: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/api/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'frame.demo.stack.client';
}
