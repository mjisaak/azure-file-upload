import { Component, OnInit, Inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    // http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
  }
  ngOnInit() {
  }

  uploadFile(event) {

    const fileList: FileList = event.files;

    const file: File = fileList[0];
    const formData: FormData = new FormData();

    formData.append('file', file, file.name);
    this.http.post(this.baseUrl + 'api/Asset', formData).subscribe();

  }

}
