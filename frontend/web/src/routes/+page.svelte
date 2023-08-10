<script lang="ts">
	import Pill from '../components/pill.svelte';
	import Player from '../components/player/player.svelte';
	import Waveform from '../components/player/waveform.svelte';

	let inputDemo = '';
</script>

<div class="m-8 space-y-4">
	<div class="flex flex-row space-x-4">
		<Pill>Kicks</Pill>
		<Pill>Drums</Pill>
		<Pill>Bass</Pill>
		<Pill>Hats</Pill>
	</div>
	<input class="input" type="search" name="demo" bind:value={inputDemo} placeholder="Search..." />

	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
	<Player />
</div>
