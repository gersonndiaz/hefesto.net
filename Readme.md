# Hefesto

Hefesto es un conjunto de utilidades escrita con .NET Standard 2.0 el cual contiene funciones tales como:

  ### Class - AspNetUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | jsonGetAllControllerActions | Obtiene listado de acciones de todos los controladores escaneados de los Assemblies del proyecto |

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
  
  ### Class - FormatUtil (Proximamente será reemplazado por Class - Rut)
  
  | Función | Descripción |
  | ------ | ------ |
  | formatRutChile | Da formato de RUT chileno a una cadena de texto |
  | removeFormatRutChile | Quita el formato a un RUT chileno |
  | calcularDv | Calcula el dígito verificador a partir de la mantisa del RUT |
  
  ### Class - Rut
  
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
  
  ### Class - HtmlUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | getFormInputs | Recibe atributos de una etiqueta Input o Textarea de HTML y retorna la estructura de la etiqueta como string |
  
  ### Class - HttpUtil
  
  | Función | Descripción |
  | ------ | ------ |
  | urlExist | Recibe una URL para comprobar si responde con código 200, comprobando la existencia de la dirección web |
  
  ### Class - Utils
  
  | Función | Descripción |
  | ------ | ------ |
  | calculateTotalPages | Recibe el N° total de registros y la cantidad que se desean mostrar para retornar la cantidad de páginas que se requieren para estructurar una paginación |

## Autores ✒️

* **Gerson Díaz** - *Creador* - [gersonndiaz](https://github.com/gersonndiaz)

## Expresiones de Gratitud 🎁

* Comenta a otros sobre este proyecto 📢
* Invita una cerveza 🍺 o un café ☕ a alguien del equipo. 
* Da las gracias públicamente 🤓.
* etc.

## Licencia 📄

Este proyecto está bajo la Licencia GPLv3 - mira el archivo [LICENSE.md](LICENSE.md) para detalles
