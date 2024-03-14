# ```circularMT``` user guide

```circularMT``` is able to read a range of file formats such as Genbank, mitos, seq, bed, fasta, gtf and gff files. For a description of each of these files can be found [here](FileFormats.md).

```circularMT``` consists of a large drawing ```Genome``` panel to the left and a single ```Options``` panel to the right (figure 1). On start up the drawing area consists of just a black circle.

![Figure 1](images/figure1.jpg)

Figure 1
<hr />

To enter a file press the ```Select``` button at the top of the ```Options``` panel and select a file. Since a large number of file formats do not contain the length of the genome, before processing the file ```circularMT``` may prompt you for length of the sequence (Figure 2). 

![Figure 2](images/figure2.jpg)

Figure 2
<hr />

 In Figure 3 the human mitochondrial genome Genbank file was selected [(download)](../Example%20data/sequence.gb) resulting in the image shown in figure 3.


![Figure 3](images/figure3.jpg)

Figure 3
<hr />

This image displays all the features found in the file as a series of arrows flanking the black circle that represents the genome. The start of the sequence is at 12 o' clock and is draw clockwise from there. Each 1 kb is marked by a line cutting the circle. The features on the outside of the circle are on the forward strand, while those on the inside are on the reverse strand. All the features are draw even if one feature covers another, for example the COX1 gene occurs in the gene and CDS feature sets. This is especially obvious for the tRNAs genes. Since there is not enough room write the tRNA's name in the arrow, it draw next to the arrow. If a number of tRNA occur in tandem, their names are fanned out to prevent them over-writing each other. However, the clusters of tRNA at about 4 and 9 o' clock contain multiple tRNAs, each duplicated in the tRNA and gene feature set, and due to the number of features ```circularMT``` as issues writing the name. This can be resolved by selecting which features to draw.

## Selecting which features to display

Just below the ```Select``` button used to pick the data file is a check box list control that lists all the different types of features found in the file. In this case there are ***source***, ***D-loop***, ***gene***, ***tRNA***, ***rRNA***, ***misc-feature*** and ***CDS***. The names of the features and what they contain depends on the data files so another file may have completely difference set. If all the features are unchecked, no features will be shown. Figures 4 to 11 shows the effect of unchecking all the options and then checking each one in turn.

![Figure 4](images/figure4.jpg)

Figure 4: No features selected
<hr />

![Figure 5](images/figure5.jpg)

Figure 5: The ***source*** feature is selected, as this is represents the whole genome it is never draw ```circularMT``` will not show features longer that 1/3 of the genome's length.
<hr />

![Figure 6](images/figure6.jpg)

Figure 6: The ***D-loop*** feature(9)s) is drawn. This feature only contains D-loops.
<hr />

![Figure 7](images/figure7.jpg)

Figure 7: The ***gene*** features are drawn, this includes the protein coding genes, rRNas and tRNAs.
<hr />

![Figure 8](images/figure8.jpg)

Figure 8: The ***tRNA*** features are drawn. This feature only contains tRNAs.
<hr />

![Figure 9](images/figure9.jpg)

Figure 9: The ***rRNA*** features are drawn. This feature only contains rRNAs.
<hr />

![Figure 10](images/figure10.jpg)

Figure 10: The ***misc_features*** are drawn: In this file the misc_features are 1 bp and so are not drawn.
<hr />

![Figure 11](images/figure11.jpg)

Figure 11: The ***CDS*** features are drawn: This feature only contains protein coding sequences.
<hr />

As can be seen from the preceding figures there may be a number of ways to display the individual sequences you are interested in. What options you select is very dependant on the data file and your needs. Generally speaking, to easily produce a nice image its best to select features that only contain one type sequence, in this case the ***D-loop***, ***tRNA***, ***rRNA*** and ***CDS*** options were selected to create Figure 12.

![Figure 12](images/figure12.jpg)

Figure 12: The th ***D-loop***, ***tRNA***, ***rRNA*** and ***CDS*** were selected such that each feature was drawn once.

<hr />

## Changing the order and/or the strands of the sequences

When working with a de novo assembled genome the contig may not be in the preferred orientation, or the sequence are annotated on the wrong strand. These issues can be resolved by checking one or both of the ```Reverse complement sequence``` or ```Switch strand``` options below the check box list options (Figure 13, 14 and 15).

![Figure 13](images/figure13.jpg)

Figure 13: Checking the ```Reverse complement sequence``` option switches the features strand and draws the sequences in the reverse order.

<hr />

![Figure 14](images/figure14.jpg)

Figure 14: Checking the ```Switch strand``` option switches the features strand, but keeps the ordering of the genes

<hr />

![Figure 15](images/figure15.jpg)

Figure 15: Checking the ```Reverse complement sequence``` and ``Switch strand``` option draws the sequences in the reverse order.

<hr />

## Changing the starting point of the genome

When working with a de novo assembled genome the contig may not start at the conventional point. Typically, mitochondrial genomes are draw with the start of tRNA encoding methionine as position 1. To rotate the image select the methionine tRNA from the dropdown list below the ```Switch strand``` option (Figure 16). The dropdown list is populated by all the currently draw features. To aid selection, the name of the feature type is shown followed by the feature's name.

![Figure 16](images/figure16.jpg)

Figure 16: Selecting the tRNA: TRNM from the dropdown list will set the start of the tRNA sequence as position 1 in the genome, rotating the image so TRNM is at 12 o' clock. 

<hr />

## Changing the feature's name for another one in the data file

Some files may have a number of different names for a feature.Not all features will have a different name, but if they do they can be selected using the second dropdown list that contains the ***Gene***, ***Product*** and  ***Gene_synoym***. Figure 17 shows the results of selecting the ***product***. This displays the fuller protein/tRNA names. However, some names are too long and cross over in the middle of the image, while other go beyond the edge of the image. To try to limit this ```circularMT``` reduces the size of the font used to write the text and make the image smaller (Figure 17). 

![Figure 17](images/figure17.jpg)

Figure 17: Selecting the product option in the second dropdown list results in the protein names been displayed, however, they are too long for the display. 

<hr />

This can be resolved by making ```circularMT's``` interface bigger.

![Figure 18](images/figure18.jpg)

Figure 18: Making the program's interface bigger helps resolve the issue. 

<hr />

## Changing the displayed length of the genome

When entering the a file such as a GTF file, you have to manually enter the size of the genome as the file doesn't necessarily contain the information. If this was in correctly entered it is possible to change it by pressing the ```Reset``` button to the right of the ```Reset genome length``` label. This will display the ```Genome length``` form (Figure 19), changing the value in the form and pressing ```OK``` will reset the length.  

![Figure 19](images/figure19.jpg)

Figure 19: Resetting the genome length with the ```Genome length``` form. 

<hr />

## Changing the Sequence's name

In the center of the image, the sequence's name is displayed. If the name is long, the font size is reduced to make it fit, however, for long names it may become hard to read. This can be resolved by shortening the name or changing it. This can be done by pressing the ```Edit``` button next to the ```Edit genome name``` label. This will display the ```Genome name``` form (Figure 20), changing the value in the form and pressing ```OK``` will reset the name.  

![Figure 20](images/figure20.jpg)

Figure 20: Resetting the genome's name with the ```Genome name``` form. 

<hr />

## Changing the colours of the features

Initially, the colours of each type of feature is based on the order in which the features occur in the file, consequently it is possible to change the colours of a feature set or specific feature by pressing the ```Adjust``` button to the right of the ```Adjust colour scheme``` button. This will display the ```Adjust feature colours``` window that allows the selection of the features to change and the new colour (Figure 21).

![Figure 21](images/figure21.jpg)

Figure 21: The ```Adjust feature colours``` window allows the colour of the features to be changed. 

<hr />

#### Selecting the feature(s) to change

The ```Adjust feature colours``` form consists of a dropdown list of the different type of features and a text box that is disabled when the form appears. To select a feature, first select its feature set from the dropdown list (Figure 22).

![Figure 22](images/figure22.jpg)

Figure 22

<hr />

Once a feature type has been selected the text box will be active, initially all the features of the chosen type will be selected and their names will appear in a list below the text box. Typing the name of the feature in the active text box, will reduce the list of selected items to those whose name starts with the entered text. For instance in Figure 23, 'ND' has been entered and so only the CDS features ***ND1***, ***ND2***, ***ND3***, ***ND4***, ***ND4L***, ***ND5*** and ***ND6*** where selected.

![Figure 23](images/figure23.jpg)

Figure 23

<hr />

Once the features have been selected, press the ```Select``` button in the lower right corner of the form to display the ```Colour``` dialog form and pick the desired colour (Figure 24) and press the ```OK``` button. This will close the dialog form and recolour the image, in this case all of the CDS features whose names start with 'ND' were redrawn (Figure 25).

![Figure 24](images/figure24.jpg)

Figure 24

<hr />

![Figure 25](images/figure25.jpg)

Figure 25

<hr />

## Drawing smaller features last

The genes on the mitochondrial genome are very tightly packed with some sequences over lapping. This may result in smaller features such as tRNAs been obscured by larger gene sequences. To reduce the affect of this, by default features longer than 150 bp are drawn first and then the remainder are draw. Unchecking the ```Draw smaller features last``` option will cause the features to be drawn in the order the feature types are listed in the check box list in the top right of the interface, with each feature in the set drawn in positional order. Figure 26 shows the affect on trnl2(taa) sequence (draw using the [results.gtf](../Example%20data/result.gtf) file) when the option is turned off (A) and turned on (B).

![Figure 26](images/figure26.jpg)

Figure 26
<hr />

## Editing the names of the features

The name of each feature is obtained from the data file, if you wish to change their names, press the ```Edit``` button to the right of the ```Edit names``` label. This will open the ```Edit feature names``` form, which is similar to the ```Adjust feature colours``` form. To edit a feature, first select its type from the dropdown list (Figure 27) and the start to type the name of the feature you wish to change in to the text area below the drop down list (this is case sensitive). When the entered text matches just one feature - only one feature appears in the text area below, the lowest text area will be come active allowing you to enter the new name (Figure 28). 

![Figure 26](images/figure27.jpg)

Figure 27
<hr />

![Figure 28](images/figure28.jpg)

Figure 28
<hr />

Pressing the ```Change``` button in the lower right of the form will rename the feature in the display (Figure 29). The ```Edit feature names``` form will remain open, allowing you to edit multiple features.

![Figure 29](images/figure29.jpg)

Figure 29
<hr />


#### Note: 
The name changes are not permanent changing the selected value in the ```Select name tag``` drop down list will reset the values to these from the file.

## Adding a feature

During the annotation process, some sequences will be missed and not included, if you have a strong reason to believe a feature should be add, you can do this by pressing the ```Add``` button to the right of the ```Add a feature``` label (the figures were made using the [result-one.fas](../Example%20data/result-one.fas) from which ***rrnl*** was removed). This will open the ```Add a feature``` form: select the feature (in this case ***Features*** is the only option and then enter the relevant information (figure 30).

![Figure 30](images/figure30.jpg)

Figure 30
<hr />

Pressing the ```Add``` button in the lower right of the form will add the feature to the image (Figure 31). The feature can now be edited like any other feature.

![Figure 31](images/figure31.jpg)

Figure 31
<hr />

## Removing a feature

During the annotation process extra features may be erroneously added, in the [results.bed](../Example%20data/result.bed) file extra replication origins have been added: ***OH_4***, ***OH_3***, ***OH_2a*** and ***OH_2b*** (Figure 32). 

![Figure 32](images/figure32.jpg)

Figure 32
<hr />

To remove unwanted features, click the ```Remove``` button next to the ```Remove a feature``` label to open the ```Delete feature(s)``` form. Once opened, select the feature type from the drop down list at the top right of the form and enter the name of feature in the activated text box (this is case sensitive) (Figure 33). If text matches one or more features, the lower right ```Delete``` button will be enabled.

![Figure 33](images/figure33.jpg)

Figure 33: The text "OH_2" matches the ***OH_2a*** and ***OH_2b*** features. Pressing the ```Delete``` button will delete them from ```circularMT's``` database. 

 Pressing the ```Delete``` button will delete any feature of the selected feature type, whose name start with the entered text (this is case sensitive) (Figure 34). Once deleted, they can not be retrieved, you'll have to either reenter the file or use the ```Add feature``` function described above. 

 
![Figure 34](images/figure34.jpg)

Figure 34: Using the ```Delete feature(s)``` form, the unwanted ***OH_4***, ***OH_3***, ***OH_2a*** and ***OH_2b*** features have been removed.
<hr />

## Recentering  the image

By default, the center of the circle representing the genome is centered on the center of the image area and the circle is rescaled to stop text disappearing off the edge of the image. However, for images with long feature names the scaling process may be stopped to make sure the image doesn't become too small and the text over runs the image or the image is smaller than you'd like (Figure 35) 

![Figure 35](images/figure35.jpg)

Figure 35: The renamed TRNF sequence causes the image to be too small.
<hr />

The two selection controls to the right of the ```Move left-right``` amd ```Move up-down``` labels allow the position of the center to be moved. As the center mores the image will rescale its self to try to stop text over running the image area. Setting the value in the control to the right of the ```Move up-down``` label to "60" will shift the image down allowing it to increase in size while still displaying the edited text for the TRNF tRNA feature (Figure 36). If you type or copy and paste a new value in to the control, you have click on another control (i.e. the other ```Move``` control or the check box list) to redraw the image.

![Figure 36](images/figure36.jpg)

Figure 36: Moving the image's center down by '60' using the ```Move up-down``` control creates a better image.
<hr />

## Saving the image to a 300 dpi image

Once the display as been adjusted, it can be saved as a 300 (are just over) dpi tif image by pressing the ```Save``` button to the right of the ```Save image``` label. This will prompt you to enter a location and file name before saving the image (Figure 37). Saving the image to a deeper resolution will also sharpen up the text written at near vertical angles which may appear scrappy in the user interface where it is drawn at ~96 dpi.

![Figure 37](images/figure37.jpg)

Figure 37: Pressing the ```Save``` button will save the current display image to a 300 dpi tif image file. 
<hr />