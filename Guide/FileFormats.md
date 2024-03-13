# circularMT

### Contents
- [Genbank](#genbank_files)  
- [Mitos](#mitos_files)  
- [Seq](#seq_files)  
- [Bed](#bed_files)  
- [Fasta](#fasta_files)  
- [GTF and GFF](#gtf-and-gff_files)  

```circularMT``` is able to read a range of file types, however the official format of many of these formats does not include all the required information so in fact it would be more coorrect to say that ```circularMT``` can read standard genbank, mitos, gtf and gff and can process extended fasta and bed files. The format and required files are described below with links to example files.

## Important note

File that appear suitable can come from a wide range of place, but their are many reasons that they are not suitable, a major issue is that ```circularMT``` expects the file to contain data on a single mitochondrial genome, some files (particularly  GTF/GFF files) may contain data on the all the chromosome in a organisms genome - ```circularMT``` will not work with these!  

## Genbank files

```circularMT``` will read Genbank files with the *.gb or *.genbank file extensions. These files were developed by the NCBI Genbank sequence database and attempt to describe sequences in as full a manner as possible. This means that they contain information that ```circularMT``` ignores. A number of sequence annotation applications can produce genbank formatted files, however, their aberrance to the stand, expected structure may vary requiring ```circularMT``` to read these files in a fault tolerant manner which may result in a poorly draw image.

#### Structure and usage

Genbank files consist of a series of sections each describing a feature over one or more lines. The start of a section is signalled by a key word appearing at the very start of a line this followed by a space and then details of the feature. Secondary data or attributes may be included as lines that start with a space, the the attributes name/type, a space and then the information. If the lines are very long, the data is wrapped across multiple lines.

A basic genbank file may have very few sections whereas those for a heavily annotated sequence my contain a very large number, each with a large number of attributes. However, ```circularMT``` will only retain data for three sections, namely the **LOCUS**, **DEFINITION** and **FEATURES**. The **Locus** section is scanned to obtain the sequence's length, while the **DEFINITION** is used to obtain the sequence's name. The **FEATURES** section contains a large numbered attributes such as ___tRNA___, ___gene___, ___CDS___, or ___origin_of_replic___, each of which in turn may have a number of attributes. Since the names of the attributes are not standardised, ```circularMT``` identifies all the names used and then collects all the features using that key word together. 

Each of the features as a set of attributes, of which ```circularMT``` retains the coordinates which are always on the first line and then looks for the naming attributes called ___/ID___, ___/gene_id___, ___/Name___, ___/gene___, ___/product___ and ___/gene_synoym___. If it finds a ___/product___ attribute the feature's product value is set to this, while a ___/gene_synonym___ sets the features gene_synonym value. All other attributes are used to set the feature's name. The last naming attribute determines the features name.

The features coordinates determine if a feature is on the forward or reverse strand for example:

> " gene&nbsp;&nbsp;&nbsp;149..1087"  
This is a gene feature on the forward strand

> " ncRNA_gene&nbsp;&nbsp;&nbsp;complement(1081..1143)"  
This is a non-coding RNA feature on the reverse strand

> " D-loop&nbsp;&nbsp;&nbsp;complement(join(16024..16569,1..576))"  
This is a D-loop feature on the reverse strand spaning the ends of the sequence. 

The ___join___ key word indicates the feature contains sequences in two or more places. In this case the first is at the start of the sequence and the other is at the end. Since mitochondrial are circular this means that the feature is one contiguous sequence, but the sequence in the file starts in the middle of the feature. ```circularMT``` will process features with only two regions, which it will try to display as one feature on the display image.

#### Example 

##### Naming lines
LOCUS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NC_020333&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;14780&nbsp;bp&nbsp;&nbsp;&nbsp;&nbsp;DNA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;circular&nbsp;INV 03-APR-2023  
DEFINITION&nbsp;&nbsp;Amblyomma cajennense mitochondrion, complete genome.  

#### Features

     source          1..14780
                     /organism="Amblyomma cajennense"
                     /organelle="mitochondrion"
                     /mol_type="genomic DNA"
                     /db_xref="taxon:34607"
     tRNA            1..68
                     /product="tRNA-Met"
                     /anticodon=(pos:36..38,aa:Met,seq:cat)
                     /codon_recognized="AUG"
     gene            69..1034
                     /gene="ND2"
                     /db_xref="GeneID:14657981"
     CDS             69..1034
                     /gene="ND2"
                     /codon_start=1
                     /transl_table=5
                     /product="NADH dehydrogenase subunit 2"
                     /protein_id="YP_007475015.1"
                     /db_xref="GeneID:14657981"
                     /translation="MLFKNVMKWLIVMTILISLSSNSWFILWLMMEMNLLIFISILNK
                     KKMNNSNLMVSYFVIQSFSSTIFFWGSLNFLIFQMFLFKMIMNISMLIKLAVVPFHFW
                     LTSLSEMIDFSSLWVILTMQKMIPLIVLYTYNVEIIIMFAAISSIIGSILALNSKTIK
                     KILIFSSISHQGWMISLILMKSNFWLTYLLIYSTLIFKISSSLTKVNFINMTSLFFIN
                     NKYPGKISIISMMLSLGGMPPFLGFFIKLMSIIILINNFNIIIIILIMSSMINIYFYL
                     RIFTPLLFLNYFSFKNYFKSNYSVKNFILTMNVIFSIFLLNVIMF"

## Mitos files

The mitos file format is a basic tab-delimited text files that contains a number of data fields of which the second is used to determine the class of feature, the name comes from the third column, while the start and end of the feature is in fields 5 and 6. Finally, the strand is obtained from the seventh field: 1 = forward and -1 = reverse. All the other fields are ignored. 

#### Example 
The first four lines of an example file are shown below:  
Note the file has no column headers.  

|Reference|Type|Name|Source|Start|End|Strand|
|-|-|-|-|-|-|-|
|L20|rRNA|rrnL|mitfi|0|1143|-1|
|L20|tRNA|trnV|mitfi|1125|1186|-1|
|L20|rRNA|rrnS|mitfi|1178|1890|-1|
|L20|rep_origin|OH|mitos|1943|2185|1|

## Seq files

Seq files start with a '>' character and the name of the reference sequence the file refers too e.g. 
>Feature L20  

where L20 is the reference sequence's name.

The remained of the file is tab-delimited text: each sequence is described over at least two lines. In any set the last line is indented bt 3 tab characters and consists of a key word describing the feature's name (i.e. ___gene___, ___product___ or ___note___) followed by a tab character and then the features name. This line is preceded by one or more lines which give the start and end points of the feature and then the type of feature. When ```circularMT``` processes a file, it reads it from the read to the beginning and appends the the last line of a description to each of the feature lines in turn to create a series of features, stored collection of each feature type as described below:

#### Example 

Text in files as found in file:

|Start|End|Feature type|attribute name|Name|
|-    |-  |-           |-             |-   |
|>Feature| L20|  
|1143|0|gene|||
|1143|	0|rRNA| | | 
| | | |product|l-rRNA|  
|1186|	1125|	gene | | | 
| | | |gene|trnV(tac)|
|1186|1125|tRNA| | |
| | | |product|tRNA-VAL|

Concatenated text process by ```circularMT```

The first line (>Feature    L20) is used to get the genome's name.

|Start|End|Feature type|attribute name|Name|
|-    |-  |-           |-             |-   | 
|1143|0|gene|product|l-rRNA|
|1143|	0| rRNA |product|l-rRNA| 
|1186|	1125| gene |gene|trnV(tac)| 
|1186|1125|tRNA|product|tRNA-VAL|



##  Bed files

The bed file format is a simple format designed to identify specific regions/features of interest in a reference sequence. It's basic format is a tab-delimited text file with the first 3 fields identifying the features reference sequence name, start point and end point respectively. The fourth and sixth columns give the feature's name and strand (+ = forward, - = reverse) any other field is ignored. Since bed files are widely used in bioinformatics not all bed files can be used ```circularMT```, but if the file came from a source that is concerned mitochondrial genomes there is a reasonable chance it will work.   


#### Example

The first four lines of an example file are shown below, the unused fields are denoted by the 'U' in the table's title row and the contents of the final unused fields have been ignored to save space.  
Note the file has no column headers. 

|Reference|Start|End|Name|U|Strand|
|-|-|-|-|-|-|
|L20|0|1144|rrnL|0.0|-|
|L20|1125|1187|trnV(tac)|3.6079e-05|-|
|L20|1178|1891|rrnS|0.0|-|
Z|20|1943|2186|OH_1|228266.8|+|


## Fasta files 

As with Bed files, fasta files are widely used and there is a very good chance a fasta file will not work, but if its source suggest it contains the relevant data it may work. Fasta files may contain one or more sequences and have a simple structure, the name of the sequence (and any attributes) is in a single line starting wit a "\>" characters, followed by the sequence. Depending on the file, the sequence may be on one line or across a series of fixed length lines. A fragment of a fasta file is shown below containing 4 sequences. The sequence name line contains the sequences name, location, strand and name separated by a ';' character. 

#### Fasta file fragment 

>L20; 1944-2186; +; OH_1
AAAACTCGTGTCTATCGGTTATCTGGACACATAAAAGAAATGTATGCTAAATTTTACTGG
ACATTCTCTCGATATTGTAAATAGGTACCTACTTAGAGCTAAATGCCATCATCTCCTTTT
TTTCTCCGAATTTATTAGTTAGTAAATGTGTGTTAGACTTAGTATGACCCTTTGTTACAT
CTATGCAGTCCAGTAAATGAGATAGCCGGTTGTCGCCCCTTATTTTCAATAGATGTGATA
ATA
>L20; 2197-2264; +; trnI(gat)
AGTAAAATGCCTGAAACTTAAAGGATTATCTTGATAGGATAAATTATGTAAATTAATTAC
TTTTACTA
>L20; 2268-2337; -; trnQ(ttg)
TAACTTTTAGTGTATAAAAAGCACAAAAAATTTTGATTTTTTAAGAAATAATTAATATTA
TTAAAGTTAT
>L20; 2341-2404; -; trnF(gaa)
ATCTTTATAGTTTAATTAAAAACATTACACTGAAAATGTAAAGAAAAACTACAATTTAAA
GATA

## GTF and GFF files

GTF and GFF version 3.0 files have very similar formats, both start with a series of lines starting with ## or \#! that contain information on the files format version and origins: these lines are ignored. The remained of the file as a standard tab-delimited text format, with the final field an array of key-value pairs. The differences between GTF and GFF ver 3 files is limited to how the final fields is formatted with the first 8 fields the same. The table below shows format for GTF/GFF v3 files with the final field replaced with 'Not shown'

#### Example of common features of a GTF and GFF v3 file

|Reference|Origin|Feature type|Start|End  | U |Strand|U|Attribute field|
| -       |  -   |  -        |  -  |  -  |-  |   -  |-|       -       |
|L20      |mitos |region     |  1  |14714|.  |   +  |.|   Not shown   |
|L20      |mitfi |ncRNA_gene |  1  |1144 |.  |   -  |.|   Not shown   |
|L20      |mitfi |rRNA       |  1  |1144 |.  |   -  |.|   Not shown   |
|L20      |mitfi |exon       |  1  |1144 |0.0|   -  |.|   Not shown   |

#### Field 9 in a GTF file

In GTF files the last field is split in to an array of key-value pairs with each key-value separated from the rest by a '; ' (note the space). Each key-value pair as the same structure: the key is a single word followed by a space and the value written between two speech marks (see table below). Each lane may contain one or more key-value pairs depending on the feature and the program that created the file.

A typical array of key-value pairs from a GTF file
> gene_id "ENSG00000211459.2"; gene_type "Mt_rRNA"; gene_name "MT-RNR1"; level 3; hgnc_id "HGNC:7470";

When broken into the key-pairs the data will be:

|Key|Value|
|-|-|
|gene_id|"ENSG00000211459.2"|
|gene_type|"Mt_rRNA"|
|gene_name|"MT-RNR1"|
level|3|
|hgnc_id|"HGNC:7470"|

When reading a GTF file ```circularMT``` looks only for the key-pairs containing the key 'gene_id' or 'transcript_name'


#### Field 9 in a GFF file

In GFF version 3 files the last field is split in to an array of key-value pairs with each key-value separated from the rest by a ';'. Each key-value pair as the same structure: the key is a single word followed by a '=' character and then the value (see table below). Each lane may contain one or more key-value pairs depending on the feature and the program that created the file.

A typical array of key-value pairs from a GFF file version 3
> ID=transcript_trnV(tac);Name=trnV(tac);Parent=gene_trnV(tac);gene_id=trnV(tac)

When broken into the key-pairs the data will be:

|Key|Value|
|-|-|
|ID|transcript_trnV(tac)| 
|Name|trnV(tac)|
|Parent|gene_trnV(tac)|
|gene_id|trnV(tac)|

When reading a GFF file ```circularMT``` looks only for the key-pairs containing the key 'Name' or 'gene_id'