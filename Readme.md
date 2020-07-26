# Hefesto

Hefesto es un conjunto de utilidades escrita con .NET Core 3.1 el cual contiene funciones tales como:

  ### Class - DataTypeValidation
  
  | Función | Descripción |
  | ------ | ------ |
  | checkEmailddress | Comprueba si una cadena de texto es un correo electrónico válido. |
  | checkGuid | Comprueba si una cadena de texto corresponde a un GUID |
  | checkRutChile | Comprueba si la cadena de texto corresponde a un RUT chileno válido |
  | checkNumber | Comprueba si el dato ingresado es un número |
  | checkUrl | Comprueba que la URL ingresada se encuentre bien formada |
  
  ### Class - SmtpUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | sendSmtpEmail | Envía un email utilizando SMTP |
  
  ### Class - EncodeUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | encodeToBase64 | Codifica una cadena de texto en base64 |
  | decodeBase64 | Decodifica una cadena base64 |
  | encodeToHex | Codifica una cadena de texto a Hexadecimal |
  | decodeHexString | Decodifica una cadena Hexadecimal |
  
  ### Class - EncryptUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | SHA512 | Encripta una cadena de texto en SHA512 |
  
  ### Class - FormatUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | formatRutChile | Da formato de RUT chileno a una cadena de texto |
  | removeFormatRutChile | Quita el formato a un RUT chileno |

  ### Class - GeneratorUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | codeGenerator | Genera un código alfanumérico aleatorio con un largo parametrizable |
  | getUniqueKey | Genera un código aleatorio único |
  
  ### Class - DirectoryUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | existsDirectory | Comprueba si existe un directorio |
  | createDirectory | Crea un nuevo directorio |
  
  ### Class - FileUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | existsFile | Comprueba si existe un archivo |
  | deleteFile | Elimina un archivo |
  | moveFile | Mueve un archivo a otro directorio |
  | copyFile | Copia un archivo a otro directorio |
  | getMimeType | Recibe una extensión de archivo y retorna el mimetype correspondiente |

License
----

GPLv3
