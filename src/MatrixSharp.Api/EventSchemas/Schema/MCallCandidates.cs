using System.Text.Json.Serialization;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event is sent by callers after sending an invite and by the callee after answering. Its purpose is to give the
	///     other party additional ICE candidates to try using to communicate.
	/// </summary>
	[MatrixEventType("m.call.candidates")]
	public record CallCandidatesEvent : RoomEvent<CallCandidatesEvent.ContentProperty>
	{
		/// <inheritdoc cref="CallCandidatesEvent" />
		public CallCandidatesEvent(ContentProperty content, string type, string eventId, string sender,
			long originServerTs, string roomId) : base(content, type, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="CallId"> The ID of the call this event relates to.</param>
		/// <param name="Candidates"> Array of objects describing the candidates.</param>
		/// <param name="Version"> The version of the VoIP specification this messages adheres to. This specification is version 0.</param>
		public record ContentProperty(
			string CallId,
			CallCandidate[] Candidates,
			int Version
		) : IContentProperty;

		/// <param name="SdpMid"> The SDP media type this candidate is intended for.</param>
		/// <param name="SdpMLineIndex"> The index of the SDP 'm' line this candidate is intended for.</param>
		/// <param name="Candidate"> The SDP 'a' line of the candidate.</param>
		public record CallCandidate(
			[property: JsonPropertyName("sdpMid")] string SdpMid,
			[property: JsonPropertyName("sdpMLineIndex")]
			double SdpMLineIndex,
			string Candidate
		);
	}
}