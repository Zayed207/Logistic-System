using System;

namespace Application.DTOs.ProofDocument
{
    public class ProofDocumentResponse
    {
        public int ProofDocumentId { get; set; }
        public int ShipmentId { get; set; }
        public short Type { get; set; }
        public byte? Status { get; set; }
        public string Photo { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }
}
