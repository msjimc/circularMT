# circularMT

### Contents
- [Genbank](#genbank-files) 
- [Mitos](#mitos-files)  
- [Seq](#seq-files)  
- [Bed](#bed-files)  
- [Fasta](#fasta-files)  
- [GTF and GFF](#gtf-and-gff-files)  

```circularMT``` is able to read a range of file types, however the official format of many of these file types does not include all the required information, so in fact it would be more correct to say that ```circularMT``` can read standard genbank and mitos, probably most seq, gtf and gff files, plus it can process 'extended' fasta and bed files. The format and required fields are described below.

## Important note

Files that appear suitable can come from a wide range of places, but there are many reasons that they are not suitable, for example ```circularMT``` expects the file to contain data on just a single mitochondrial genome, some files (particularly  GTF/GFF files) may contain data on all the chromosomes in a organism's genome - ```circularMT``` will try to work with these, but fail!  

## Genbank files

```circularMT``` will read Genbank files with the *.gb or *.genbank file extensions. These files were developed for the NCBI Genbank sequence database and attempts to describe sequences in as full a manner as possible. This means that they contain information that ```circularMT``` ignores. A number of sequence annotation applications also produce genbank formatted files, however, their adherence to the standard, expected structure may vary requiring ```circularMT``` to read these files in a fault tolerant manner which may result in a poorly draw image.

An official NCBI - Genbank file for a human mitochondrial genome that is used for the majority of the user guide is [here](../Example%20data/sequence.gb).  

### Structure and usage

Genbank files consist of a series of sections each describing a feature over one or more lines. The start of a section is signalled by a key word appearing at the very start of a line, followed by a space and then the details of the feature. Secondary data or attributes may be included as lines that start with a space, followed by the attributes name/type, a second space and then the information. If the lines are very long, the data is wrapped across multiple lines.

A basic genbank file may have very few sections, whereas those for a heavily annotated sequence my contain a lot of sections each containing multiple attributes. ```circularMT``` will only retain data from three sections, namely the **LOCUS**, **DEFINITION** and **FEATURES** sections. The **Locus** section is scanned to obtain the sequence's length, while the **DEFINITION** is used to obtain the sequence's name. The **FEATURES** section contains a large numbered attributes such as multiple ___tRNA___, ___gene___, ___CDS___, or ___origin_of_replic___ features, each of which in turn may have a number of attributes. Since the names of the attributes are not standardised, ```circularMT``` identifies all the names used and then collects all the features using that key word together. 

Each of the features as a set of attributes, of which ```circularMT``` retains the coordinates which are always on the first line and then looks for the naming attributes called ___/ID___, ___/gene_id___, ___/Name___, ___/gene___, ___/product___ and ___/gene_synoym___. If it finds a ___/product___ attribute the feature's product value is set to this, while a ___/gene_synonym___ sets the features gene_synonym value. All other attributes are used to set the feature's name. The last naming attribute determines the feature's name.

The feature's coordinates determine if a feature is on the forward or reverse strand for example:

> " gene&nbsp;&nbsp;&nbsp;149..1087"  

Is for a feature on the forward strand

> " ncRNA_gene&nbsp;&nbsp;&nbsp;complement(1081..1143)"  

Is for a feature on the reverse strand

> " D-loop&nbsp;&nbsp;&nbsp;complement(join(16024..16569,1..576))"  

Is for a feature on the reverse strand spanning the ends of the sequence.  
 - The ___join___ key word indicates the feature contains sequences in two or more places. In this case the first is at the end of the genome and the second is at the start. Since mitochondrial genomes are circular, this suggests that the feature is one contiguous sequence, but the genome sequence in the file starts in the middle of the feature, so part maps to the start of the sequence and the rest maps to the end of the sequence. ```circularMT``` will process features with only two regions, which it will try to display as one feature on the display image.

### Structure  

#### Genome attribute lines
```circularMT``` will use the following line to get the sequence length: 14780  
>LOCUS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NC_020333&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;14780&nbsp;bp&nbsp;&nbsp;&nbsp;&nbsp;DNA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;circular&nbsp;INV 03-APR-2023

and will use the following line to get the sequence name: "Amblyomma cajennense mitochondrion, complete genome."  

>DEFINITION&nbsp;&nbsp;Amblyomma cajennense mitochondrion, complete genome.  


#### Features
The following text is fragment from a Genbank ***FEATURES*** section:

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

From the fragment above ```circularMT``` will retain 4 features:
|Feature type|Location|Gene name|Product name|Strand|
|-|-|-|-|-|
|source| 1 to 14780|Not present|Not present|Forward|
|tRNA| 1 to 68| tRNA-Met|Not present|Forward|
|gene| 69 to 1034|  ND2| NADH dehydrogenase subunit 2|Forward|
|CDS| 69 to 1034|  ND2|NADH dehydrogenase subunit 2|Forward|

It can be seen that the ND2 sequence occurs as both a ***Gene*** feature and a ***CDS*** feature.

## Mitos files

The mitos file format is a basic tab-delimited text format and created by the MITOS application currently hosted on Galaxy. Each line for contains a number of data fields for each feature, of which the second is used to determine the class of feature, the name comes from the third column, while the start and end of the feature are in fields 5 and 6. Finally, the strand is obtained from the seventh field: 1 = forward and -1 = reverse. All the other fields are ignored (and not necessarily shown below). 

### Structure 
The first four lines of an example file are shown below:  
#### Note: the file has no column headers.  

|Reference|Type|Name|Source|Start|End|Strand|
|-|-|-|-|-|-|-|
|MT-1|rRNA|rrnL|mitfi|0|1143|-1|
|MT-1|tRNA|trnV|mitfi|1125|1186|-1|
|MT-1|rRNA|rrnS|mitfi|1178|1890|-1|
|MT-1|rep_origin|OH|mitos|1943|2185|1|


From the fragment above ```circularMT``` will retain 4 features:
|Feature type|Location|Gene name|Strand|
|-|-|-|-|
|rRNA|0 to 1143|rrnL|Reverse|
|tRNA|1125 to 1186|trnV|Reverse|
|rRNA|1178 to 1890|trnS|Reverse|
|rep_origin|1943 to 2185|OH|Forward|

## Seq files

Seq files start with a '>Feature' and the name of the reference sequence the file refers too, for example:    
&#62;Feature MT-1  
where MT-1 is the reference sequence's name.

The remainder of the file is tab-delimited text: each region of interest is described across a set of at least two lines. In any set the last line is indented by 3 tab characters and consists of a key word describing the feature's sub-type (i.e. ___gene___, ___product___ or ___note___) followed by a tab character and then the feature's name. This line is preceded by one or more lines which give the start and end points of the feature and then the type of feature. When ```circularMT``` processes a file, it reads it from the end to the beginning, and appends the the last line of a description to each of the feature lines in turn to create a series of features as described below:

### Structure 
The file fragment below shows the first 8 lines of a seq file.

|Start|End|Feature type|attribute name|Name|
|-    |-  |-           |-             |-   |
|>Feature| MT-1|  
|1143|0|gene|||
|1143|	0|rRNA| | | 
| | | |product|l-rRNA|  
|1186|	1125|	gene | | | 
| | | |gene|trnV(tac)|
|1186|1125|tRNA| | |
| | | |product|tRNA-VAL|

When processed the lines are concatenated by ```circularMT``` to create those shown below, which are then used to create 4 features.

(The first line (>Feature    MT-1) is used to get the genome's name.)

|Feature|Start|End|Feature type|attribute name|Name|
|-|-    |-  |-           |-             |-   | 
|1|1143|0|gene|product|l-rRNA|
|2|1143|	0| rRNA |product|l-rRNA| 
|3|1186|	1125| gene |gene|trnV(tac)| 
|4|1186|1125|tRNA|product|tRNA-VAL|

Features with an end value lower than the start value are set as on the reverse strand. If the annotated mitochondrial genome sequence starts in a feature, part will be mapped to the end of the genome and the rest will be mapped to start of the genome, this may give a feature coordinates similar to 1,4000 to 7. If the genome is 14,500 bp long the feature is given the coordinates of 14,000 to 14,507. This over hangs the end of the sequence, but ```circularMT``` will wrap it round.

From the file fragment above ```circularMT``` will retain 4 features:   
|Feature type|Location|Gene name|Strand|
|-|-|-|-|
|gene|0 to 1143|l-rRNA|Reverse|
|rRNA|0 to 1143|l-rRNA|Reverse|
|gene|1125 to 1186|trnV(tac)|Reverse|
|tRNA|1125 to 1186|tRNA-VAL|Reverse|

##  Bed files

The bed file format is a simple format designed to identify specific regions/features of interest in a genome which in turn is typically saved as a multiple sequence fasta file. It is  a tab-delimited text file with the first 3 fields identifying the features reference sequence name, start point and end point of the feature respectively. The fourth and sixth columns give the feature's name and strand (+ = forward, - = reverse) any other field is ignored. Since bed files are widely used in bioinformatics, not all bed files can be used by ```circularMT```, but if the file came from a source that is concerned with mitochondrial genomes there is a reasonable chance it will work.   

### Structure

The first four lines of a bed file are shown below, the unused fields are denoted by the 'U' in the table's header row and the contents of the unused fields after the 'strand' field have been omitted to save space.  

Note the file has no column headers. 

|Reference|Start|End|Name|U|Strand|
|-|-|-|-|-|-|
|MT-1|0|1144|rrnL|0.0|-|
|MT-1|1125|1187|trnV(tac)|3.6079e-05|-|
|MT-1|1178|1891|rrnS|0.0|-|
|20|1943|2186|OH_1|228266.8|+|

From the file fragment above ```circularMT``` will retain 4 features: 

|Feature type|Location|Gene name|Strand|
|-|-|-|-|
|feature|1 to 1144|rrnL|Reverse|
|feature|1125 to 1187|trnV(tac)|Reverse|
|feature|1178 to 1891|rrnS|Reverse|
|feature|1943 to 2186|OH_1|Forward|

## Fasta files 

As with Bed files, fasta files are widely used and there is a very good chance a fasta file will not work, but if its source suggest it contains the relevant data it may work. Fasta files may contain one or more sequences and have a simple structure. The name of the sequence (and any attributes) is in a single line starting with a "\>" characters, followed by the sequence on the following line(s). Depending on the file, the sequence may be on one line or across a series of fixed length lines. A fragment of a fasta file is shown below containing 4 sequences. The sequence name line contains the sequence's name, location, strand and the feature's name separated by a ';' character. 

### Structure 

&#62;MT-1; 1944-2186; +; OH_1   
AAAACTCGTGTCTATCGGTTATCTGGACACATAAAAGAAATGTATGCTAAATTTTACTGG  
ACATTCTCTCGATATTGTAAATAGGTACCTACTTAGAGCTAAATGCCATCATCTCCTTTT  
TTTCTCCGAATTTATTAGTTAGTAAATGTGTGTTAGACTTAGTATGACCCTTTGTTACAT  
CTATGCAGTCCAGTAAATGAGATAGCCGGTTGTCGCCCCTTATTTTCAATAGATGTGATA  
ATA  
&#62;MT-1; 2197-2264; +; trnI(gat)  
AGTAAAATGCCTGAAACTTAAAGGATTATCTTGATAGGATAAATTATGTAAATTAATTAC  
TTTTACTA  
&#62;MT-1; 2268-2337; -; trnQ(ttg)  
TAACTTTTAGTGTATAAAAAGCACAAAAAATTTTGATTTTTTAAGAAATAATTAATATTA  
TTAAAGTTAT  
&#62;MT-1; 2341-2404; -; trnF(gaa)  
ATCTTTATAGTTTAATTAAAAACATTACACTGAAAATGTAAAGAAAAACTACAATTTAAA  
GATA  

Analysis of this fragment will produce the following features:

|Start|End|Name|Strand|
|-|-|-|-|
|1944|2186|OH-1|+|
|2197|2264|trnI(gat)|+|
|2268|2337|trnQ(ttg)|-|
|2341|2404|trnF(gaa)|-|

Since the file doesn't contain a feature's type all the features are saved as type - Feature.

## GTF and GFF files

GTF and GFF version 3.0 files have very similar formats, both start with a series of lines starting with ## or \#! that contain information on the file's format, version and origins: these lines are ignored. The remainder of the file has a standard tab-delimited text format, with the final field an array of key-value pairs. The differences between GTF and GFF ver 3 files is limited to how the final field is formatted with the first 8 fields the same. The table below shows the format for GTF/GFF v3 files with the final field replaced with 'Not shown'

### Structure of common features of a GTF and GFF v3 file

|Reference|Origin|Feature type|Start|End  | U |Strand|U|Attribute field|
| -       |  -   |  -        |  -  |  -  |-  |   -  |-|       -       |
|MT-1      |mitos |region     |  1  |14714|.  |   +  |.|   Not shown   |
|MT-1      |mitfi |ncRNA_gene |  1  |1144 |.  |   -  |.|   Not shown   |
|MT-1      |mitfi |rRNA       |  1  |1144 |.  |   -  |.|   Not shown   |
|MT-1      |mitfi |exon       |  1  |1144 |0.0|   -  |.|   Not shown   |

The data in the ___Feature type___, ___Start___, ___End___ and ___Strand___ fields are retained.

### Attribute field in a GTF file

In GTF files the last field is split in to an array of key-value pairs with each key-value pair separated a '; ' (note the space). Each key-value pair as the same structure: the key is a single word followed by a space and the value written between two speech marks (see table below). Each line may contain one or more key-value pairs depending on the feature and the program that created the file.



A typical array of key-value pairs from a GTF file is shown below:
> gene_id "ENSG00000211459.2"; gene_type "Mt_rRNA"; gene_name "MT-RNR1"; level 3; hgnc_id "HGNC:7470";

When broken into the key-pairs the data will be:

|Key|Value|
|-|-|
|gene_id|"ENSG00000211459.2"|
|gene_type|"Mt_rRNA"|
|gene_name|"MT-RNR1"|
level|3|
|hgnc_id|"HGNC:7470"|

When reading a GTF file ```circularMT``` looks only for the key-pairs containing the  'gene_id' or 'transcript_name' key.


### Attribute field in a GFF file

In GFF version 3 files the last field is split in to an array of key-value pairs with each key-value separated from the rest by a ';' character. Each key-value pair consists of the key as a single word followed by a '=' character and finally the value (see table below). Each line may contain one or more key-value pairs depending on the feature and the program that created the file.

A typical array of key-value pairs from a GFF file version 3 is shown below:
> ID=transcript_trnV(tac);Name=trnV(tac);Parent=gene_trnV(tac);gene_id=trnV(tac)

When broken into the key-pairs the data will be:

|Key|Value|
|-|-|
|ID|transcript_trnV(tac)| 
|Name|trnV(tac)|
|Parent|gene_trnV(tac)|
|gene_id|trnV(tac)|

When reading a GFF file ```circularMT``` looks only for the key-pairs containing the 'Name' or 'gene_id' keys.