# circularMT

### Contents

```circularMT``` is able to read a range of file types, however the official format of many of these formats does not include all the required information so in fact it would be more coorrect to say that ```circularMT``` can read standard genbank, mitos, gtf and gff and can process extended fasta and bed files. The format and required files are described below with links to example files.

### Genbank

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

### Mitos

The mitos file format is a basic tab-delimited text files that contains a number of data fields of which the second is used to determine the class of feature, the name comes from the third column, while the start and end of the feature is in fields 5 and 6. Finally, the strand is obtained from the seventh field: 1 = forward and -1 = reverse. All the other fields are ignored. he first four lines of an example file are shown below (note the file has no column headers) 

#### Example 

|Reference name|Type|Name|Source|Start|End|Strand|
|-|-|-|-|-|-|-|
|L20|rRNA|rrnL|mitfi|0|1143|-1|
|L20|tRNA|trnV|mitfi|1125|1186|-1|
|L20|rRNA|rrnS|mitfi|1178|1890|-1|
|L20|rep_origin|OH|mitos|1943|2185|1|

### Bed

The bed file format is a simple format designed to identify specific regions/features of interest in a reference sequence. It's basic format is a tab-delimited text file with the first 3 fields identifying the features reference sequence name, start point and end point respectively. The fourth and sixth columns give the feature's name and strand (+ = forward, - = reverse) any other field is ignored. Since bed files are widely used in bioinformatics not all bed files can be used ```circularMT```, but if the file came from a source that is concerned mitochondrial genomes there is a reasonable chance it will work.   
The first four lines of an example file are shown below (note the file has no column headers). The unused fields are denoted by the 'U' in the table's title row and the contents of the final unused fields have been ignored to save space.

#### Example
|Reference name|Start|End|Name|unused|Strand|
|-|-|-|-|-|-|
|L20|	0|	1144|	rrnL|	0.0|	-|
|L20|1125|	1187|	trnV(tac)|	3.600000127335079e-05|	-|
|L20|1178|	1891|	rrnS|	0.0|	-|
Z|20|1943|	2186|	OH_1|	228266.8|	+|


### Fasta 

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

### GTF and GFF