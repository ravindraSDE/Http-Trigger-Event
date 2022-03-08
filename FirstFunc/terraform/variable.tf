variable "project" {
  type        = string
  description = "Project name"
}

variable "environment" {
  type        = string
  description = "Environment (dev / stage / prod)"
}

variable "location" {
  type        = string
  description = "Azure region to deploy module to"
}

variable "functionapp_source" {
  type    = string
  default = "F:/VisualStudio/Projects/FirstFunc/FirstFunc/bin/Debug/netcoreapp3.1/publish"
}


variable "functionapp" {
  type    = string
  default = "C:/Users/hp/Desktop/QuadrantResource/AzureFunction/PublishedAzureFunctions/publishedAzureFunctions.zip"
}

variable "storage_blob" {
  type    = string
  default = "my-first-function-deployment-zip"
}
