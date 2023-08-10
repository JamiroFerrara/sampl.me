<script lang="ts">
	import Addbutton from './addbutton.svelte';
	import Playbutton from './playbutton.svelte';
	import Waveform from './waveform.svelte';

	let playing = false;
</script>

<div class="flex flex-row w-full">
	<Playbutton {playing} onChange={(value) => (playing = value)} />
	<Waveform {playing} />
	<Addbutton />
</div>
