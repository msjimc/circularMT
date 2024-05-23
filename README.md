# circularMT

### Command line version 
This application is designed as a desktop application, however, a command line console version is available [here](https://github.com/msjimc/circularMT/tree/ddfd7039e0ca9e12ff99396b319034f22ec7c4dd/circularMT-console). The command line version creates the same type of images as ```circularMT```, but is less flexible. It is assumed ```circularMT-console``` will be used as part of a generic pipeline, while ```circularMT``` will be used to create images for papers or theses etc.

## Contents

- [Introduction](#Introduction)
- [Guide](#guide)
- [Download](#download)
- [Running on Linux systems](#running-on-linux-systems)

## Introduction

<img align="right" src="Guide/images/introCircular.jpg">

```circularMT``` is designed to create images of the genomic organisation of mitochondrial genomes that can be used to display the arrangement of the genes they encode. Images can be exported as 300 dpi TIFF, bitmap, PNG or JPEG files for use in reports, publications or a thesis. The maps can be circular like the one to the right or linear like the one below.

The data can be imported from a wide range of file formats such as *.fasta, *.mitos, *.gb, *.bed, *.seq, *.gtf and *.gff files. While ```circularMT``` can process these files, *.fasta and *.bed files in particular most conform to a set format not present in all files.

Once imported the resultant image can be rotated, the strands switched around and the features renamed, deleted and colour scheme changed to obtain the desired map.

<center><img src="Guide/images/introLineear.jpg"></center>

## Guide

The user guide is [here](Guide/README.md).

## Download

The prebuilt program can be downloaded [here](Program/README.md).

## Running on Linux systems

The prebuilt programs can be run on Linux (and macOS) using the Wine package as described [here](Linux_with_Wine/README.md).


## Zenodo archive

An archived version of the first release is available  from here:   
[![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.10912319.svg)](https://doi.org/10.5281/zenodo.10912319)

