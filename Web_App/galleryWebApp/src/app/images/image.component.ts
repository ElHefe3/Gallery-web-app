import { Component, OnInit } from '@angular/core';
import {Gallery} from '../../app/models';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})
export class ImageComponent implements OnInit {

  public images = [
    {
      url: 'https://image.shutterstock.com/image-vector/sample-stamp-grunge-texture-vector-260nw-1389188336.jpg',
      row: '1',
      col: '1'
    },
    {
      url: 'https://image.shutterstock.com/image-vector/sample-stamp-grunge-texture-vector-260nw-1389188336.jpg',
      row: '1',
      col: '2'
    },
    {
      url: 'https://image.shutterstock.com/image-vector/sample-stamp-grunge-texture-vector-260nw-1389188336.jpg',
      row: '2',
      col: '1'
    },
    {
      url: 'https://image.shutterstock.com/image-vector/sample-stamp-grunge-texture-vector-260nw-1389188336.jpg',
      row: '2',
      col: '2'
    },
    {
      url: 'https://image.shutterstock.com/image-vector/sample-stamp-grunge-texture-vector-260nw-1389188336.jpg',
      row: '3',
      col: '1'
    },
    {
      url: 'https://image.shutterstock.com/image-vector/sample-stamp-grunge-texture-vector-260nw-1389188336.jpg',
      row: '3',
      col: '2'
    },
  ] as Array<Gallery>;

  constructor() { }

  ngOnInit(): void {
  }

}
