Imports System.Net
Imports System.IO

Public Function GetImageAsBase64(url As String) As String
    ' Cria uma solicitação HTTP para o URL especificado
    Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
    
    ' Faz a solicitação e obtém a resposta
    Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
    
    ' Obtém o fluxo de dados da resposta
    Using stream As Stream = response.GetResponseStream()
        ' Cria um MemoryStream para armazenar a imagem
        Using memoryStream As New MemoryStream()
            ' Copia os dados do fluxo para o MemoryStream
            stream.CopyTo(memoryStream)
            
            ' Converte os dados da imagem em um array de bytes
            Dim imageBytes As Byte() = memoryStream.ToArray()
            
            ' Converte o array de bytes em uma string Base64
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            
            ' Retorna a string Base64 contendo a imagem
            Return base64String
        End Using
    End Using
End Function
