﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;

using iTin.Core.Helpers;

namespace iTin.AspNet;

/// <summary>
/// Maps document extensions to content <b>MIME</b> types.
/// </summary>
/// <remarks>
/// For more information, please see <a href="http://www.freeformatter.com/mime-types-list.html">http://www.freeformatter.com/mime-types-list.html</a>
/// </remarks>
public static class MimeMapping
{
    #region private static readonly member fields

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly Dictionary<string, string> MappingDictionary = new(StringComparer.OrdinalIgnoreCase)
    {
        { "*", "application/octet-stream" },                                                              // Wildcard (Default)
        { "x3d", "application/vnd.hzn-3d-crossword" },                                                    // 3D Crossword Plugin
        { "3gp", "video/3gpp" },                                                                          // 3GP
        { "3g2", "video/3gpp2" },                                                                         // 3GP2
        { "pwn", "application/vnd.3m.post-it-notes" },                                                    // 3M Post It Notes
        { "plb", "application/vnd.3gpp.pic-bw-large" },                                                   // 3rd Generation Partnership Project - Pic Large
        { "psb", "application/vnd.3gpp.pic-bw-small" },                                                   // 3rd Generation Partnership Project - Pic Small
        { "pvb", "application/vnd.3gpp.pic-bw-var" },                                                     // 3rd Generation Partnership Project - Pic Var
        { "tcap", "application/vnd.3gpp2.tcap" },                                                         // 3rd Generation Partnership Project - Transaction Capabilities Application Part
        { "7z", "application/x-7z-compressed" },                                                          // 7-Zip
        { "abw", "application/x-abiword" },                                                               // AbiWord
        { "ace", "application/x-ace-compressed" },                                                        // Ace Archive
        { "acc", "application/vnd.americandynamics.acc" },                                                // Active Content Compression
        { "acu", "application/vnd.acucobol" },                                                            // ACU Cobol
        { "atc", "application/vnd.acucorp" },                                                             // ACU Cobol
        { "adp", "audio/adpcm" },                                                                         // Adaptive differential pulse-code modulation
        { "aab", "application/x-authorware-bin" },                                                        // Adobe (Macropedia) Authorware - Binary File
        { "aam", "application/x-authorware-map" },                                                        // Adobe (Macropedia) Authorware - Map
        { "aas", "application/x-authorware-seg" },                                                        // Adobe (Macropedia) Authorware - Segment File
        { "air", "application/vnd.adobe.air-application-installer-package+zip" },                         // Adobe AIR Application
        { "swf", "application/x-shockwave-flash" },                                                       // Adobe Flash
        { "fxp", "application/vnd.adobe.fxp" },                                                           // Adobe Flex Project
        { "pdf", "application/pdf" },                                                                     // Adobe Portable Document
        { "ppd", "application/vnd.cups-ppd" },                                                            // Adobe PostScript Printer Description File Format
        { "dir", "application/x-director" },                                                              // Adobe Shockwave Player
        { "xdp", "application/vnd.adobe.xdp+xml" },                                                       // Adobe XML Data Package
        { "xfdf", "application/vnd.adobe.xfdf" },                                                         // Adobe XML Forms Data Format
        { "aac", "audio/x-aac" },                                                                         // Advanced Audio Coding (AAC)
        { "ahead", "application/vnd.ahead.space" },                                                       // Ahead AIR Application
        { "azf", "application/vnd.airzip.filesecure.azf" },                                               // AirZip FileSECURE
        { "azs", "application/vnd.airzip.filesecure.azs" },                                               // AirZip FileSECURE
        { "azw", "application/vnd.amazon.ebook" },                                                        // Amazon Kindle eBook format
        { "ami", "application/vnd.amiga.ami" },                                                           // AmigaDE
        { "apk", "application/vnd.android.package-archive" },                                             // Android Package Archive
        { "cii", "application/vnd.anser-web-certificate-issue-initiation" },                              // ANSER-WEB Terminal Client - Certificate Issue
        { "fti", "application/vnd.anser-web-funds-transfer-initiation" },                                 // ANSER-WEB Terminal Client - Web Funds Transfer
        { "atx", "application/vnd.antix.game-component" },                                                // Antix Game Player
        { "mpkg", "application/vnd.apple.installer+xml" },                                                // Apple Installer Package
        { "aw", "application/applixware" },                                                               // Applixware
        { "les", "application/vnd.hhe.lesson-player" },                                                   // Archipelago Lesson Player
        { "swi", "application/vnd.aristanetworks.swi" },                                                  // Arista Networks Software Image
        { "s", "text/x-asm" },                                                                            // Assembler Source File
        { "atomcat", "application/atomcat+xml" },                                                         // Atom Publishing Protocol
        { "atomsvc", "application/atomsvc+xml" },                                                         // Atom Publishing Protocol Service Document
        { "atom", "application/atom+xml" },                                                               // Atom Syndication Format
        { "ac", "application/pkix-attr-cert" },                                                           // Attribute Certificate
        { "aif", "audio/x-aiff" },                                                                        // Audio Interchange File Format
        { "avi", "video/x-msvideo" },                                                                     // Audio Video Interleave (AVI)
        { "aep", "application/vnd.audiograph" },                                                          // Audiograph
        { "dxf", "image/vnd.dxf" },                                                                       // AutoCAD DXF
        { "dwf", "model/vnd.dwf" },                                                                       // Autodesk Design Web Format (DWF)
        { "par", "text/plain-bas" },                                                                      // BAS Partitur Format
        { "bcpio", "application/x-bcpio" },                                                               // Binary CPIO Archive
        { "bin", "application/octet-stream" },                                                            // Binary Data
        { "bmp", "image/bmp" },                                                                           // Bitmap Image File
        { "torrent", "application/x-bittorrent" },                                                        // BitTorrent
        { "cod", "application/vnd.rim.cod" },                                                             // Blackberry COD File
        { "mpm", "application/vnd.blueice.multipass" },                                                   // Blueice Research Multipass
        { "bmi", "application/vnd.bmi" },                                                                 // BMI Drawing Data Interchange
        { "sh", "application/x-sh" },                                                                     // Bourne Shell Script
        { "btif", "image/prs.btif" },                                                                     // BTIF
        { "rep", "application/vnd.businessobjects" },                                                     // BusinessObjects
        { "bz", "application/x-bzip" },                                                                   // Bzip Archive
        { "bz2", "application/x-bzip2" },                                                                 // Bzip2 Archive
        { "csh", "application/x-csh" },                                                                   // C Shell Script
        { "c", "text/x-c" },                                                                              // C Source File
        { "cdxml", "application/vnd.chemdraw+xml" },                                                      // CambridgeSoft Chem Draw
        { "css", "text/css" },                                                                            // Cascading Style Sheets (CSS)
        { "cdx", "chemical/x-cdx" },                                                                      // ChemDraw eXchange file
        { "cml", "chemical/x-cml" },                                                                      // Chemical Markup Language
        { "csml", "chemical/x-csml" },                                                                    // Chemical Style Markup Language
        { "cdbcmsg", "application/vnd.contact.cmsg" },                                                    // CIM Database
        { "cla", "application/vnd.claymore" },                                                            // Claymore Data Files
        { "c4g", "application/vnd.clonk.c4group" },                                                       // Clonk Game
        { "sub", "image/vnd.dvb.subtitle" },                                                              // Close Captioning - Subtitle
        { "cdmia", "application/cdmi-capability" },                                                       // Cloud Data Management Interface (CDMI) - Capability
        { "cdmic", "application/cdmi-container" },                                                        // Cloud Data Management Interface (CDMI) - Contaimer
        { "cdmid", "application/cdmi-domain" },                                                           // Cloud Data Management Interface (CDMI) - Domain
        { "cdmio", "application/cdmi-object" },                                                           // Cloud Data Management Interface (CDMI) - Object
        { "cdmiq", "application/cdmi-queue" },                                                            // Cloud Data Management Interface (CDMI) - Queue
        { "c11amc", "application/vnd.cluetrust.cartomobile-config" },                                     // ClueTrust CartoMobile - Config
        { "c11amz", "application/vnd.cluetrust.cartomobile-config-pkg" },                                 // ClueTrust CartoMobile - Config Package
        { "ras", "image/x-cmu-raster" },                                                                  // CMU Image
        { "dae", "model/vnd.collada+xml" },                                                               // COLLADA
        { "csv", "text/csv"},                                                                             // Comma-Seperated Values
        { "cpt", "application/mac-compactpro" },                                                          // Compact Pro
        { "wmlc", "application/vnd.wap.wmlc" },                                                           // Compiled Wireless Markup Language (WMLC)
        { "cgm", "image/cgm" },                                                                           // Computer Graphics Metafile
        { "ice", "x-conference/x-cooltalk" },                                                             // CoolTalk
        { "cmx", "image/x-cmx" },                                                                         // Corel Metafile Exchange (CMX)
        { "xar", "application/vnd.xara" },                                                                // CorelXARA
        { "cmc", "application/vnd.cosmocaller" },                                                         // CosmoCaller
        { "cpio", "application/x-cpio" },                                                                 // CPIO Archive
        { "clkx", "application/vnd.crick.clicker" },                                                      // CrickSoftware - Clicker
        {"clkk", "application/vnd.crick.clicker.keyboard" },                                              // CrickSoftware - Clicker - Keyboard
        {"clkp", "application/vnd.crick.clicker.palette" },                                               // CrickSoftware - Clicker - Palette
        {"clkt", "application/vnd.crick.clicker.template"},                                               // CrickSoftware - Clicker - Template
        {"clkw", "application/vnd.crick.clicker.wordbank"},                                               // CrickSoftware - Clicker - Wordbank
        {"wbs", "application/vnd.criticaltools.wbs+xml" },                                                // Critical Tools - PERT Chart EXPERT
        {"cryptonote", "application/vnd.rig.cryptonote" },                                                // CryptoNote
        {"cif", "chemical/x-cif" },                                                                       // Crystallographic Interchange Format
        {"cmdf", "chemical/x-cmdf" },                                                                     // CrystalMaker Data Format
        {"cu", "application/cu-seeme" },                                                                  // CU-SeeMe
        {"cww", "application/prs.cww" },                                                                  // CU-Writer
        {"curl", "text/vnd.curl" },                                                                       // Curl - Applet
        {"dcurl", "text/vnd.curl.dcurl" },                                                                // Curl - Detached Applet
        {"mcurl", "text/vnd.curl.mcurl" },                                                                // Curl - Manifest File
        {"scurl", "text/vnd.curl.scurl" },                                                                // Curl - Source Code
        {"car", "application/vnd.curl.car" },                                                             // CURL Applet
        {"pcurl", "application/vnd.curl.pcurl" },                                                         // CURL Applet
        {"cmp", "application/vnd.yellowriver-custom-menu" },                                              // CustomMenu
        { "dssc", "application/dssc+der" },                                                               // Data Structure for the Security Suitability of Cryptographic Algorithms
        { "xdssc", "application/dssc+xml" },                                                              // Data Structure for the Security Suitability of Cryptographic Algorithms
        { "deb", "application/x-debian-package" },                                                        // Debian Package
        { "uva", "audio/vnd.dece.audio" },                                                                // DECE Audio
        { "uvi", "image/vnd.dece.graphic" },                                                              // DECE Graphic
        { "uvh", "video/vnd.dece.hd" },                                                                   // DECE High Definition Video
        { "uvm", "video/vnd.dece.mobile" },                                                               // DECE Mobile Video
        { "uvu", "video/vnd.uvvu.mp4" },                                                                  // DECE MP4
        { "uvp", "video/vnd.dece.pd" },                                                                   // DECE PD Video
        { "uvs", "video/vnd.dece.sd" },                                                                   // DECE SD Video
        { "uvv", "video/vnd.dece.video" },                                                                // DECE Video
        { "dvi", "application/x-dvi" },                                                                   // Device Independent File Format (DVI)
        { "seed", "application/vnd.fdsn.seed" },                                                          // Digital Siesmograph Networks - SEED Datafiles
        { "dtb", "application/x-dtbook+xml" },                                                            // Digital Talking Book
        { "res", "application/x-dtbresource+xml" },                                                       // Digital Talking Book - Resource File
        { "ait", "application/vnd.dvb.ait" },                                                             // Digital Video Broadcasting
        { "svc", "application/vnd.dvb.service" },                                                         // Digital Video Broadcasting
        { "eol", "audio/vnd.digital-winds" },                                                             // Digital Winds Music
        { "djvu", "image/vnd.djvu" },                                                                     // DjVu
        { "dtd", "application/xml-dtd" },                                                                 // Document Type Definition
        { "mlp", "application/vnd.dolby.mlp" },                                                           // Dolby Meridian Lossless Packing
        { "wad", "application/x-doom" },                                                                  // Doom Video Game
        { "dpg", "application/vnd.dpgraph" },                                                             // DPGraph
        { "dra", "audio/vnd.dra" },                                                                       // DRA Audio
        { "dfac", "application/vnd.dreamfactory" },                                                       // DreamFactory
        { "dts", "audio/vnd.dts" },                                                                       // DTS Audio
        { "dtshd", "audio/vnd.dts.hd" },                                                                  // DTS High Definition Audio
        { "dwg", "image/vnd.dwg" },                                                                       // DWG Drawing
        { "geo", "application/vnd.dynageo" },                                                             // DynaGeo
        { "es", "application/ecmascript" },                                                               // ECMAScript
        { "mag", "application/vnd.ecowin.chart" },                                                        // EcoWin Chart
        { "mmr", "image/vnd.fujixerox.edmics-mmr" },                                                      // EDMICS 2000
        { "rlc", "image/vnd.fujixerox.edmics-rlc" },                                                      // EDMICS 2000
        { "exi", "application/exi" },                                                                     // Efficient XML Interchange
        { "mgz", "application/vnd.proteus.magazine" },                                                    // EFI Proteus
        { "epub", "application/epub+zip" },                                                               // Electronic Publication
        { "eml", "message/rfc822" },                                                                      // Email Message
        { "nml", "application/vnd.enliven" },                                                             // Enliven Viewer
        { "mdb", "application/x-msaccess" },                                                              // Microsoft Access
        { "asf", "video/x-ms-asf" },                                                                      // Microsoft Advanced Systems Format (ASF)
        { "exe", "application/x-msdownload" },                                                            // Microsoft Application
        { "cil", "application/vnd.ms-artgalry" },                                                         // Microsoft Artgalry
        { "cab", "application/vnd.ms-cab-compressed" },                                                   // Microsoft Cabinet File
        { "ims", "application/vnd.ms-ims" },                                                              // Microsoft Class Server
        { "application", "application/x-ms-application" },                                                // Microsoft ClickOnce
        { "clp", "application/x-msclip" },                                                                // Microsoft Clipboard Clip
        { "mdi", "image/vnd.ms-modi" },                                                                   // Microsoft Document Imaging Format
        { "eot", "application/vnd.ms-fontobject" },                                                       // Microsoft Embedded OpenType
        { "xls", "application/vnd.ms-excel" },                                                            // Microsoft Excel
        { "xlam", "application/vnd.ms-excel.addin.macroenabled.12" },                                     // Microsoft Excel - Add-In File
        { "xlsb", "application/vnd.ms-excel.sheet.binary.macroenabled.12" },                              // Microsoft Excel - Binary Workbook
        { "xltm", "application/vnd.ms-excel.template.macroenabled.12" },                                  // Microsoft Excel - Macro-Enabled Template File
        { "xlsm", "application/vnd.ms-excel.sheet.macroenabled.12" },                                     // Microsoft Excel - Macro-Enabled Workbook
        { "chm", "application/vnd.ms-htmlhelp" },                                                         // Microsoft Html Help File                        
        { "crd", "application/x-mscardfile" },                                                            // Microsoft Information Card
        { "lrm", "application/vnd.ms-lrm" },                                                              // Microsoft Learning Resource Module
        { "mvb", "application/x-msmediaview" },                                                           // Microsoft MediaView
        { "mny", "application/x-msmoney" },                                                               // Microsoft Money
        { "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },          // Microsoft Office - OOXML - Presentation
        { "sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide" },                 // Microsoft Office - OOXML - Presentation (Slide)
        { "ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow" },             // Microsoft Office - OOXML - Presentation (Slideshow)
        { "potx", "application/vnd.openxmlformats-officedocument.presentationml.template" },              // Microsoft Office - OOXML - Presentation Template
        { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },                  // Microsoft Office - OOXML - Spreadsheet
        { "xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template" },               // Microsoft Office - OOXML - Spreadsheet Teplate
        { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },            // Microsoft Office - OOXML - Word Document                                                
        { "dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template" },            // Microsoft Office - OOXML - Word Document Template
        { "obd", "application/x-msbinder" },                                                              // Microsoft Office Binder
        { "thmx", "application/vnd.ms-officetheme" },                                                     // Microsoft Office System Release Theme
        { "onetoc", "application/onenote" },                                                              // Microsoft OneNote
        { "pya", "audio/vnd.ms-playready.media.pya" },                                                    // Microsoft PlayReady Ecosystem
        { "pyv", "video/vnd.ms-playready.media.pyv" },                                                    // Microsoft PlayReady Ecosystem Video
        { "ppt", "application/vnd.ms-powerpoint" },                                                       // Microsoft PowerPoint
        { "ppam", "application/vnd.ms-powerpoint.addin.macroenabled.12" },                                // Microsoft PowerPoint - Add-in file
        { "sldm", "application/vnd.ms-powerpoint.slide.macroenabled.12" },                                // Microsoft PowerPoint - Macro-Enabled Open XML Slide
        { "pptm", "application/vnd.ms-powerpoint.presentation.macroenabled.12" },                         // Microsoft PowerPoint - Macro-Enabled Presentation File
        { "ppsm", "application/vnd.ms-powerpoint.slideshow.macroenabled.12" },                            // Microsoft PowerPoint - Macro-Enabled Slide Show File
        { "mpp", "application/vnd.ms-project" },                                                          // Microsoft Project
        { "pub", "application/x-mspublisher" },                                                           // Microsoft Publisher
        { "scd", "application/x-msschedule" },                                                            // Microsoft Schedule+
        { "xap", "application/x-silverlight-app" },                                                       // Microsoft Silverlight
        { "stl", "application/vnd.ms-pki.stl" },                                                          // Microsoft Trust UI Provider - Certificate Trust Link
        { "cat", "application/vnd.ms-pki.seccat" },                                                       // Microsoft Trust UI Provider - Security Catalog
        { "vsd", "application/vnd.visio" },                                                               // Microsoft Visio
        { "wm", "video/x-ms-wm" },                                                                        // Microsoft Windows Media
        { "wma", "audio/x-ms-wma" },                                                                      // Microsoft Windows Media Audio
        { "wax", "audio/x-ms-wax" },                                                                      // Microsoft Windows Media Audio Redirector                     
        { "wmx", "video/x-ms-wmx" },                                                                      // Microsoft Windows Media Audio/Video Playlist
        { "wmd", "application/x-ms-wmd" },                                                                // Microsoft Windows Media Player Download Package
        { "wpl", "application/vnd.ms-wpl" },                                                              // Microsoft Windows Media Player Playlist
        { "wmz", "application/x-ms-wmz" },                                                                // Microsoft Windows Media Player Skin Package
        { "wmv", "video/x-ms-wmv" },                                                                      // Microsoft Windows Media Video
        { "wvx", "video/x-ms-wvx" },                                                                      // Microsoft Windows Media Video Playlist
        { "wmf", "application/x-msmetafile" },                                                            // Microsoft Windows Metafile
        { "trm", "application/x-msterminal" },                                                            // Microsoft Windows Terminal Services
        { "doc", "application/msword" },                                                                  // Microsoft Word
        { "wri", "application/x-mswrite" },                                                               // Microsoft Wordpad
        { "wps", "application/vnd.ms-works" },                                                            // Microsoft Works
        { "xbap", "application/x-ms-xbap" },                                                              // Microsoft XAML Browser Application
        { "xps", "application/vnd.ms-xpsdocument" },                                                      // Microsoft XML Paper Specification                      
        { "potm", "application/vnd.ms-powerpoint.template.macroenabled.12" },                             // Micosoft PowerPoint - Macro-Enabled Template File 
        { "docm", "application/vnd.ms-word.document.macroenabled.12" },                                   // Micosoft Word - Macro-Enabled Document
        { "dotm", "application/vnd.ms-word.template.macroenabled.12" },                                   // Micosoft Word - Macro-Enabled Template                     
        { "h261", "video/h261" },                                                                         // H.261
        { "h263", "video/h263" },                                                                         // H.263
        { "h264", "video/h264" },                                                                         // H.264
        { "odc", "application/vnd.oasis.opendocument.chart" },                                            // OpenDocument Chart
        { "otc", "application/vnd.oasis.opendocument.chart-template" },                                   // OpenDocument Chart Template
        { "odb", "application/vnd.oasis.opendocument.database" },                                         // OpenDocument Database
        { "odf", "application/vnd.oasis.opendocument.formula" },                                          // OpenDocument Formula
        { "odft", "application/vnd.oasis.opendocument.formula-template" },                                // OpenDocument Formula Template
        { "odg", "application/vnd.oasis.opendocument.graphics" },                                         // OpenDocument Graphics
        { "otg", "application/vnd.oasis.opendocument.graphics-template" },                                // OpenDocument Graphics Template
        { "odi", "application/vnd.oasis.opendocument.image" },                                            // OpenDocument Image
        { "oti", "application/vnd.oasis.opendocument.image-template" },                                   // OpenDocument Image Template
        { "odp", "application/vnd.oasis.opendocument.presentation" },                                     // OpenDocument Presentation
        { "otp", "application/vnd.oasis.opendocument.presentation-template" },                            // OpenDocument Presentation Template
        { "ods", "application/vnd.oasis.opendocument.spreadsheet" },                                      // OpenDocument Spreadsheet
        { "ots", "application/vnd.oasis.opendocument.spreadsheet-template" },                             // OpenDocument Spreadsheet Template
        { "odt", "application/vnd.oasis.opendocument.text" },                                             // OpenDocument Text
        { "odm", "application/vnd.oasis.opendocument.text-master" },                                      // OpenDocument Text Master
        { "ott", "application/vnd.oasis.opendocument.text-template" },                                    // OpenDocument Text Template
        { "ktx", "image/ktx" },                                                                           // OpenGL Textures (KTX)
        { "sxc", "application/vnd.sun.xml.calc" },                                                        // OpenOffice - Calc (Spreadsheet)
        { "stc", "application/vnd.sun.xml.calc.template" },                                               // OpenOffice - Calc Template (Spreadsheet)
        { "sxd", "application/vnd.sun.xml.draw" },                                                        // OpenOffice - Draw (Graphics)
        { "std", "application/vnd.sun.xml.draw.template" },                                               // OpenOffice - Draw Template (Graphics)
        { "sxi", "application/vnd.sun.xml.impress" },                                                     // OpenOffice - Impress (Presentation)
        { "sti", "application/vnd.sun.xml.impress.template" },                                            // OpenOffice - Impress Template (Presentation)
        { "sxm", "application/vnd.sun.xml.math" },                                                        // OpenOffice - Math (Formula)
        { "sxw", "application/vnd.sun.xml.writer" },                                                      // OpenOffice - Writer (Text - HTML)
        { "sxg", "application/vnd.sun.xml.writer.global" },                                               // OpenOffice - Writer (Text - HTML)
        { "stw", "application/vnd.sun.xml.writer.template" },                                             // OpenOffice - Writer Template (Text - HTML)
        { "otf", "application/x-font-otf" },                                                              // OpenType Font File
        { "mj2", "video/mj2" },                                                                           // Motion JPEG 2000
        { "mpga", "audio/mpeg" },                                                                         // MPEG Audio
        { "mxu", "video/vnd.mpegurl" },                                                                   // MPEG Url
        { "mpeg", "video/mpeg" },                                                                         // MPEG Video
        { "m21", "application/mp21" },                                                                    // MPEG-21
        { "mp4a", "audio/mp4" },                                                                          // MPEG-4 Audio
        { "mp4", "video/mp4" },                                                                           // MPEG-4 Video
        { "tex", "application/x-tex" },                                                                   // TeX
        { "tfm", "application/x-tex-tfm" },                                                               // TeX Font Metric
        { "tei", "application/tei+xml" },                                                                 // Text Encoding and Interchange
        { "txt", "text/plain" },                                                                          // Text File
        { "xpr", "application/vnd.is-xpr" },                                                              // Express by Infoseek
        { "xif", "image/vnd.xiff" },                                                                      // eXtended Image File Format (XIFF)
        { "xfdl", "application/vnd.xfdl" },                                                               // Extensible Forms Description Language
        { "emma", "application/emma+xml" },                                                               // Extensible MultiModal Annotation
        { "ez2", "application/vnd.ezpix-album" },                                                         // EZPix Secure Photo Album
        { "ez3", "application/vnd.ezpix-package" },                                                       // EZPix Secure Photo Album
        { "fst", "image/vnd.fst" },                                                                       // FAST Search & Transfer ASA
        { "fvt", "video/vnd.fvt" },                                                                       // FAST Search & Transfer ASA
        { "fbs", "image/vnd.fastbidsheet" },                                                              // FastBid Sheet
        { "fe_launch", "application/vnd.denovo.fcselayout-link" },                                        // FCS Express Layout Link
        { "f4v", "video/x-f4v" },                                                                         // Flash Video
        { "flv", "video/x-flv" },                                                                         // Flash Video
        { "fpx", "image/vnd.fpx" },                                                                       // FlashPix
        { "npx", "image/vnd.net-fpx" },                                                                   // FlashPix
        { "flx", "text/vnd.fmi.flexstor" },                                                               // FLEXSTOR
        { "fli", "video/x-fli" },                                                                         // FLI/FLC Animation Format
        { "ftc", "application/vnd.fluxtime.clip" },                                                       // FluxTime Clip
        { "fdf", "application/vnd.fdf" },                                                                 // Forms Data Format
        { "f", "text/x-fortran" },                                                                        // Fortran Source File
        { "mif", "application/vnd.mif" },                                                                 // FrameMaker Interchange Format
        { "fm", "application/vnd.framemaker" },                                                           // FrameMaker Normal Format
        { "fh", "image/x-freehand" },                                                                     // FreeHand MX
        { "fsc", "application/vnd.fsc.weblaunch" },                                                       // Friendly Software Corporation
        { "fnc", "application/vnd.frogans.fnc" },                                                         // Frogans Player
        { "ltf", "application/vnd.frogans.ltf" },                                                         // Frogans Player
        { "ddd", "application/vnd.fujixerox.ddd" },                                                       // Fujitsu - Xerox 2D CAD Data
        { "xdw", "application/vnd.fujixerox.docuworks" },                                                 // Fujitsu - Xerox DocuWorks
        { "xbd", "application/vnd.fujixerox.docuworks.binder" },                                          // Fujitsu - Xerox DocuWorks Binder
        { "oas", "application/vnd.fujitsu.oasys" },                                                       // Fujitsu Oasys
        { "oa2", "application/vnd.fujitsu.oasys2" },                                                      // Fujitsu Oasys
        { "oa3", "application/vnd.fujitsu.oasys3" },                                                      // Fujitsu Oasys
        { "fg5", "application/vnd.fujitsu.oasysgp" },                                                     // Fujitsu Oasys
        { "bh2", "application/vnd.fujitsu.oasysprs" },                                                    // Fujitsu Oasys
        { "spl", "application/x-futuresplash" },                                                          // FutureSplash Animator
        { "fzs", "application/vnd.fuzzysheet" },                                                          // FuzzySheet
        { "g3", "image/g3fax" },                                                                          // G3 Fax Image
        { "gmx", "application/vnd.gmx" },                                                                 // GameMaker ActiveX
        { "gtw", "model/vnd.gtw" },                                                                       // Gen-Trix Studio
        { "txd", "application/vnd.genomatix.tuxedo" },                                                    // Genomatix Tuxedo Framework
        { "ggb", "application/vnd.geogebra.file" },                                                       // GeoGebra
        { "ggt", "application/vnd.geogebra.tool" },                                                       // GeoGebra
        { "gdl", "model/vnd.gdl" },                                                                       // Geometric Description Language (GDL)
        { "gex", "application/vnd.geometry-explorer" },                                                   // GeoMetry Explorer
        { "gxt", "application/vnd.geonext" },                                                             // GEONExT and JSXGraph
        { "g2w", "application/vnd.geoplan" },                                                             // GeoplanW
        { "g3w", "application/vnd.geospace" },                                                            // GeospacW
        { "gsf", "application/x-font-ghostscript" },                                                      // Ghostscript Font
        { "bdf", "application/x-font-bdf" },                                                              // Glyph Bitmap Distribution Format
        { "gtar", "application/x-gtar" },                                                                 // GNU Tar Files
        { "texinfo", "application/x-texinfo" },                                                           // GNU Texinfo Document
        { "gnumeric", "application/x-gnumeric" },                                                         // Gnumeric
        { "kml", "application/vnd.google-earth.kml+xml" },                                                // Google Earth - KML
        { "kmz", "application/vnd.google-earth.kmz" },                                                    // Google Earth - Zipped KML
        { "gqf", "application/vnd.grafeq" },                                                              // GrafEq
        { "gif", "image/gif" },                                                                           // Graphics Interchange Format
        { "gv", "text/vnd.graphviz" },                                                                    // Graphviz
        { "gac", "application/vnd.groove-account" },                                                      // Groove - Account
        { "ghf", "application/vnd.groove-help" },                                                         // Groove - Help
        { "gim", "application/vnd.groove-identity-message" },                                             // Groove - Identity Message
        { "grv", "application/vnd.groove-injector" },                                                     // Groove - Injector
        { "gtm", "application/vnd.groove-tool-message" },                                                 // Groove - Tool Message
        { "tpl", "application/vnd.groove-tool-template" },                                                // Groove - Tool Template
        { "vcg", "application/vnd.groove-vcard" },                                                        // Groove - Vcard
        { "hpid", "application/vnd.hp-hpid" },                                                            // Hewlett Packard Instant Delivery
        { "hps", "application/vnd.hp-hps" },                                                              // Hewlett-Packard's WebPrintSmart Hierarchical Data Format
        { "hdf", "application/x-hdf" },                                                                   // Hierarchical Data Format
        { "rip", "audio/vnd.rip" },                                                                       // Hit'n'Mix
        { "hbci", "application/vnd.hbci" },                                                               // Homebanking Computer Interface (HBCI)
        { "jlt", "application/vnd.hp-jlyt" },                                                             // HP Indigo Digital Press - Job Layout Languate
        { "pcl", "application/vnd.hp-pcl" },                                                              // HP Printer Command Language
        { "hpgl", "application/vnd.hp-hpgl" },                                                            // HP-GL/2 and HP RTL
        { "hvs", "application/vnd.yamaha.hv-script" },                                                    // HV Script
        { "hvd", "application/vnd.yamaha.hv-dic" },                                                       // HV Voice Dictionary
        { "hvp", "application/vnd.yamaha.hv-voice" },                                                     // HV Voice Parameter
        { "sfd-hdstx", "application/vnd.hydrostatix.sof-data" },                                          // Hydrostatix Master Suite
        { "stk", "application/hyperstudio" },                                                             // Hyperstudio
        { "hal", "application/vnd.hal+xml" },                                                             // Hypertext Application Language
        { "html", "text/html" },                                                                          // HyperText Markup Language (HTML)
        { "irm", "application/vnd.ibm.rights-management" },                                               // IBM DB2 Rights Manager
        { "sc", "application/vnd.ibm.secure-container" },                                                 // IBM Electronic Media Management System - Secure Container
        { "ics", "text/calendar" },                                                                       // iCalendar
        { "icc", "application/vnd.iccprofile" },                                                          // ICC profile
        { "ico", "image/x-icon" },                                                                        // Icon Image
        { "igl", "application/vnd.igloader" },                                                            // igLoader
        { "ief", "image/ief" },                                                                           // Image Exchange Format
        { "ivp", "application/vnd.immervision-ivp" },                                                     // ImmerVision PURE Players
        { "ivu", "application/vnd.immervision-ivu" },                                                     // ImmerVision PURE Players
        { "rif", "application/reginfo+xml" },                                                             // IMS Networks
        { "3dml", "text/vnd.in3d.3dml" },                                                                 // In3D - 3DML
        { "spot", "text/vnd.in3d.spot" },                                                                 // In3D - 3DML
        { "igs", "model/iges" },                                                                          // Initial Graphics Exchange Specification (IGES)
        { "i2g", "application/vnd.intergeo" },                                                            // Interactive Geometry Software
        { "cdy", "application/vnd.cinderella" },                                                          // Interactive Geometry Software Cinderella
        { "xpw", "application/vnd.intercon.formnet" },                                                    // Intercon FormNet
        { "fcs", "application/vnd.isac.fcs" },                                                            // International Society for Advancement of Cytometry
        { "ipfix", "application/ipfix" },                                                                 // Internet Protocol Flow Information Export
        { "cer", "application/pkix-cert" },                                                               // Internet Public Key Infrastructure - Certificate
        { "pki", "application/pkixcmp" },                                                                 // Internet Public Key Infrastructure - Certificate Management Protocole
        { "crl", "application/pkix-crl" },                                                                // Internet Public Key Infrastructure - Certificate Revocation Lists
        { "pkipath", "application/pkix-pkipath" },                                                        // Internet Public Key Infrastructure - Certification Path
        { "igm", "application/vnd.insors.igm" },                                                          // IOCOM Visimeet
        { "rcprofile", "application/vnd.ipunplugged.rcprofile" },                                         // IP Unplugged Roaming Client
        { "irp", "application/vnd.irepository.package+xml" },                                             // iRepository / Lucidoc Editor
        { "jad", "text/vnd.sun.j2me.app-descriptor" },                                                    // J2ME App Descriptor
        { "jar", "application/java-archive" },                                                            // Java Archive
        { "class", "application/java-vm" },                                                               // Java Bytecode File
        { "jnlp", "application/x-java-jnlp-file" },                                                       // Java Network Launching Protocol
        { "ser", "application/java-serialized-object" },                                                  // Java Serialized Object
        { "java", "text/x-java-source,java" },                                                            // Java Source File
        { "js", "application/javascript" },                                                               // JavaScript
        { "json", "application/json" },                                                                   // JavaScript Object Notation (JSON)
        { "joda", "application/vnd.joost.joda-archive" },                                                 // Joda Archive
        { "jpm", "video/jpm" },                                                                           // JPEG 2000 Compound Image File Format
        { "jpg", "image/jpg" },                                                                           // JPEG Image
        { "jpeg", "image/jpeg" },                                                                         // JPEG Image
        { "jpgv", "video/jpeg" },                                                                         // JPGVideo
        { "ktz", "application/vnd.kahootz" },                                                             // Kahootz
        { "sql", "application/x-sql" },                                                                   // Sql file
        { "mmd", "application/vnd.chipnuts.karaoke-mmd" },                                                // Karaoke on Chipnuts Chipsets
        { "karbon", "application/vnd.kde.karbon" },                                                       // KDE KOffice Office Suite - Karbon
        { "chrt", "application/vnd.kde.kchart" },                                                         // KDE KOffice Office Suite - KChart
        { "kfo", "application/vnd.kde.kformula" },                                                        // KDE KOffice Office Suite - Kformula
        { "flw", "application/vnd.kde.kivio" },                                                           // KDE KOffice Office Suite - Kivio
        { "kon", "application/vnd.kde.kontour" },                                                         // KDE KOffice Office Suite - Kontour
        { "kpr", "application/vnd.kde.kpresenter" },                                                      // KDE KOffice Office Suite - Kpresenter
        { "ksp", "application/vnd.kde.kspread" },                                                         // KDE KOffice Office Suite - Kspread
        { "kwd", "application/vnd.kde.kword" },                                                           // KDE KOffice Office Suite - Kword
        { "123", "application/vnd.lotus-1-2-3" },                                                         // Lotus 1-2-3
        { "apr", "application/vnd.lotus-approach" },                                                      // Lotus Approach
        { "pre", "application/vnd.lotus-freelance" },                                                     // Lotus Freelance
        { "nsf", "application/vnd.lotus-notes" },                                                         // Lotus Notes
        { "org", "application/vnd.lotus-organizer" },                                                     // Lotus Organizer
        { "scm", "application/vnd.lotus-screencam" },                                                     // Lotus Screencam
        { "lwp", "application/vnd.lotus-wordpro" },                                                       // Lotus Wordpro
        { "oda", "application/oda" },                                                                     // Office Document Architecture
        { "ogx", "application/ogg" },                                                                     // Ogg
        { "oga", "audio/ogg" },                                                                           // Ogg Audio
        { "ogv", "video/ogg" },                                                                           // Ogg Video
        { "dd2", "application/vnd.oma.dd2+xmlg" },                                                        // OMA Download Agents
        { "oth", "application/vnd.oasis.opendocument.text-web" },                                         // Open Document Text Web
        { "opf", "application/oebps-package+xml" },                                                       // Open eBook Publication Structure
        { "qbo", "application/vnd.intu.qbo" },                                                            // Open Financial Exchange
        { "oxt", "application/vnd.openofficeorg.extension" },                                             // Open Office Extension
        { "osf", "application/vnd.yamaha.openscoreformat" },                                              // Open Score Format
        { "weba", "audio/webm" },                                                                         // Open Web Media Project - Audio
        { "webm", "video/webm" },                                                                         // Open Web Media Project - Video
        { "osfpvg", "application/vnd.yamaha.openscoreformat.osfpvg+xml" },                                // OSFPVG
        { "dp", "application/vnd.osgi.dp" },                                                              // OSGi Deployment Package
        { "pdb", "application/vnd.palm" },                                                                // PalmOS Data
        { "p", "text/x-pascal" },                                                                         // Pascal Source File
        { "pnm", "image/x-portable-anymap" },                                                             // Portable Anymap Image
        { "pbm", "image/x-portable-bitmap" },                                                             // Portable Bitmap Format
        { "pcf", "application/x-font-pcf" },                                                              // Portable Compiled Format
        { "pfr", "application/font-tdpfr" },                                                              // Portable Font Resource
        { "pgn", "application/x-chess-pgn" },                                                             // Portable Game Notation (Chess Games)
        { "pgm", "image/x-portable-graymap" },                                                            // Portable Graymap Format
        { "png", "image/png" },                                                                           // Portable Network Graphics (PNG)
        { "ppm", "image/x-portable-pixmap" },                                                             // Portable Pixmap Format
        { "pskcxml", "application/pskc+xml" },                                                            // Portable Symmetric Key Container
        { "pml", "application/vnd.ctc-posml" },                                                           // PosML
        { "ai", "application/postscript" },                                                               // PostScript
        { "pfa", "application/x-font-type1" },                                                            // PostScript Fonts
        { "pbd", "application/vnd.powerbuilder6" },                                                       // PowerBuilder
        { "qfx", "application/vnd.intu.qfx" },                                                            // Quicken
        { "qt", "video/quicktime" },                                                                      // Quicktime Video
        { "rar", "application/x-rar-compressed" },                                                        // RAR Archive
        { "ram", "audio/x-pn-realaudio" },                                                                // Real Audio Sound
        { "rmp", "audio/x-pn-realaudio-plugin" },                                                         // Real Audio Sound
        { "rsd", "application/rsd+xml" },                                                                 // Really Simple Discovery
        { "rm", "application/vnd.rn-realmedia" },                                                         // RealMedia
        { "bed", "application/vnd.realvnc.bed" },                                                         // RealVNC
        { "sgml", "text/sgml" },                                                                          // Standard Generalized Markup Language (SGML)
        { "sdc", "application/vnd.stardivision.calc" },                                                   // StarOffice - Calc
        { "sda", "application/vnd.stardivision.draw" },                                                   // StarOffice - Draw
        { "sdd", "application/vnd.stardivision.impress" },                                                // StarOffice - Impress
        { "smf", "application/vnd.stardivision.math" },                                                   // StarOffice - Math 
        { "sdw", "application/vnd.stardivision.writer" },                                                 // StarOffice - Writer
        { "sgl", "application/vnd.stardivision.writer-global"} ,                                          // StarOffice - Writer (Global)
        { "rtf", "application/rtf" },                                                                     // Rich Text Format
        { "rtx", "text/richtext" },                                                                       // Rich Text Format (RTF)
        { "sis", "application/vnd.symbian.install" },                                                     // Symbian Install Package     
        { "vbs", "text/vbscript" },                                                                       // Visual Basic Script
        { "vcd", "application/x-cdlink" },                                                                // Video CD
        { "src", "application/x-wais-source" },                                                           // WAIS Source
        { "wbxml", "application/vnd.wap.wbxml" },                                                         // WAP Binary XML (WBXML)
        { "wbmp", "image/vnd.wap.wbmp" },                                                                 // WAP Bitamp (WBMP)
        { "wav", "audio/x-wav" },                                                                         // Waveform Audio File Format (WAV)
        { "davmount", "application/davmount+xml" },                                                       // Web Distributed Authoring and Versioning
        { "woff", "application/x-font-woff" },                                                            // Web Open Font Format
        { "wspolicy", "application/wspolicy+xml" },                                                       // Web Services Policy
        { "webp", "image/webp"},                                                                          // WebP Image
        { "wtb", "application/vnd.webturbo" },                                                            // WebTurbo
        { "wgt", "application/widget" },                                                                  // Widget Packaging and XML Configuration
        { "hlp", "application/winhlp" },                                                                  // WinHelp
        { "wml", "text/vnd.wap.wml" },                                                                    // Wireless Markup Language (WML)
        { "wmls", "text/vnd.wap.wmlscript" },                                                             // Wireless Markup Language Script (WMLScript)
        { "wmlsc", "application/vnd.wap.wmlscriptc" },                                                    // WMLScript
        { "wpd", "application/vnd.wordperfect" },                                                         // Wordperfect
        { "stf", "application/vnd.wt.stf" },                                                              // Worldtalk
        { "wsdl", "application/wsdl+xml" },                                                               // WSDL - Web Services Description Language
        { "xbm", "image/x-xbitmap" },                                                                     // X BitMap
        { "xpm", "image/x-xpixmap" },                                                                     // X PixMap
        { "xwd", "image/x-xwindowdump" },                                                                 // X Window Dump
        { "der", "application/x-x509-ca-cert" },                                                          // X.509 Certificate
        { "fig", "application/x-xfig" },                                                                  // Xfig
        { "xhtml", "application/xhtml+xml" },                                                             // XHTML - The Extensible HyperText Markup Language
        { "xml", "application/xml" },                                                                     // XML - Extensible Markup Language
        { "xdf", "application/xcap-diff+xml" },                                                           // XML Configuration Access Protocol - XCAP Diff
        { "xenc", "application/xenc+xml" },                                                               // XML Encryption Syntax and Processing
        { "xer", "application/patch-ops-error+xml" },                                                     // XML Patch Framework
        { "rl", "application/resource-lists+xml" },                                                       // XML Resource Lists
        { "rs", "application/rls-services+xml" },                                                         // XML Resource Lists
        { "rld", "application/resource-lists-diff+xml" },                                                 // XML Resource Lists Diff
        { "xslt", "application/xslt+xml" },                                                               // XML Transformations
        { "xop", "application/xop+xml" },                                                                 // XML-Binary Optimized Packaging
        { "xpi", "application/x-xpinstall" },                                                             // XPInstall - Mozilla
        { "xspf", "application/xspf+xml" },                                                               // XSPF - XML Shareable Playlist Format
        { "xul", "application/vnd.mozilla.xul+xml" },                                                     // XUL - XML User Interface Language
        { "xyz", "chemical/x-xyz" },                                                                      // XYZ File Format
        { "yang", "application/yang" },                                                                   // YANG Data Modeling Language
        { "yin", "application/yin+xml" },                                                                 // YIN (YANG - XML)
        { "zir", "application/vnd.zul" },                                                                 // Z.U.L. Geometry
        { "zip", "application/zip" },                                                                     // Zip Archive
        { "zmm", "application/vnd.handheld-entertainment+xml" },                                          // ZVUE Media Manager
        { "zaz", "application/vnd.zzazz.deck+xml" }                                                       // Zzazz Deck
    };

    #endregion

    #region public static methods

    /// <summary>
    /// Returns the <b>MIME</b> mapping for the specified file extension.
    /// </summary>
    /// <param name="extension">The file extension that is used to determine the <b>MIME</b> type.</param>
    /// <returns>
    /// A <see cref="T:System.String" /> that contains the <b>MIME</b> type.
    /// </returns>
    /// <example>
    /// The following code example, you get the mime type for pdf extension.
    /// <code lang="cs">
    ///   using System;   
    /// 
    ///   using iTin.AspNet.Web;
    /// 
    ///   class SampleClass   
    ///   {   
    ///       static int Main()   
    ///       {
    ///            // Gets the mime type.
    ///            string mime = MimeMapping.GetMimeMapping("pdf");
    /// 
    ///            // Print the result => 'application/pdf'
    ///            Console.WriteLine("MIME type for pdf extension is {0}", mime); 
    ///       }
    ///   }   
    ///  </code>
    /// </example>
    public static string GetMimeMapping(string extension)
    {
        SentinelHelper.ArgumentNull(extension, nameof(extension));

        string extensionWithoutDot = extension.Replace(".", string.Empty);

        bool hasMimeMapping = MappingDictionary.TryGetValue(extensionWithoutDot, out var mimeType);
        return hasMimeMapping ? mimeType : MappingDictionary["*"];
    }

    #endregion
}
