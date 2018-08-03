import { Component } from '@angular/core';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent  {

  private fileUploaded: boolean;

  constructor() {
  }

  uploadFile(event) {
    this.fileUploaded = true;
  }
}
