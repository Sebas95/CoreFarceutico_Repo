
USE FARMATICA;
Insert Into Receta(Image)
   Select BulkColumn 
   from Openrowset (Bulk 'C:\Users\Sebastian\Desktop\receta.png', Single_Blob) as Image
